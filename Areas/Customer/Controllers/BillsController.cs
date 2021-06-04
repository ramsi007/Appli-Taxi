using Appli_Taxi.Data;
using Appli_Taxi.Models;
using Appli_Taxi.Models.ViewModels;
using Appli_Taxi.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Appli_Taxi.Areas.Customer.Controllers
{
    [Authorize]
    [Area("Customer")]
    public class BillsController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly IEmailSender _emailSender;

        public BillsController(ApplicationDbContext _db, IEmailSender emailSender)
        {
            this.db = _db;
            _emailSender = emailSender;
        }

        BillDetailsViewModel BillDetailsVM = new BillDetailsViewModel();


        public async Task<IActionResult> Index()
        {
            var ListBills = new List<Bill>();
            if (User.IsInRole(SD.ManagerUser))
            {
                ListBills = await db.Bills.Include(m => m.ApplicationUser).ToListAsync();
            }
            else
            {
                ListBills = await db.Bills.Include(m => m.ApplicationUser)
                       .Where(m => m.UserId == GetUserId()).ToListAsync();
            }

            return View(ListBills);
        }

        public async Task<IActionResult> Create(string id)
        {
            var bill = new Bill();
            bill.IssueDate = Convert.ToDateTime(DateTime.Now.ToString("dd-MMMM-yyyy"));
            bill.DueDate = Convert.ToDateTime(DateTime.Now.ToString("dd-MMMM-yyyy"));

            BillDetailsVM.ShooppingCart = new ShooppingCart();
            BillDetailsVM.ApplicationUser = new ApplicationUser();

            if (id == null)
            {
                BillDetailsVM.UsersList = await db.ApplicationUsers.ToListAsync();
                bill.NumBill = null;
            }
            else
            {

                BillDetailsVM.ShooppingCart.ApplicationUserId = await db.ApplicationUsers.Where(m => m.Id == id).Select(m => m.Id)
                                                                    .FirstOrDefaultAsync();
                BillDetailsVM.ApplicationUser = await db.ApplicationUsers.Where(m => m.Id == id).FirstOrDefaultAsync();
                bill.NumBill = ("#Fact/" + DateTime.Now.ToFileTime().ToString()).Substring(1, 18);
            }

            BillDetailsVM.ListShoppingCarts = await db.ShooppingCarts.Where(m => m.ApplicationUserId == id
                                                            && m.NumBill != null).ToListAsync();

            foreach (var cart in BillDetailsVM.ListShoppingCarts)
            {
                bill.BillTotalOrginal += (cart.Price + (cart.Price * cart.Tax / 100)) * cart.Count;

                bill.Remise += cart.Remise;
            }
            bill.BillTotal = bill.BillTotalOrginal - bill.Remise;
            BillDetailsVM.Bill = bill;

            return View(BillDetailsVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BillDetailsViewModel model)
        {
            Bill bill = new Bill()
            {
                UserId = model.ApplicationUser.Id,
                IssueDate = model.Bill.IssueDate,
                DueDate = model.Bill.DueDate,
                Status = SD.StatusNotPaid,
                PhoneNumber = model.ApplicationUser.PhoneNumber,
                BillType = model.Bill.BillType,
                BillTotal = model.Bill.BillTotal,
                BillTotalOrginal = model.Bill.BillTotalOrginal,
                NumBill = model.Bill.NumBill,
                Remise = model.Bill.Remise,
                Rest = model.Bill.BillTotal
            };

            await db.Bills.AddAsync(bill);
            await db.SaveChangesAsync();
            var shoopingcartList = await db.ShooppingCarts.Where(m => m.ApplicationUserId
                        == model.ApplicationUser.Id && m.NumBill != null).ToListAsync();

            foreach (var item in shoopingcartList)
            {

                BillDetail billDetail = new BillDetail()
                {
                    BillId = bill.Id,
                    ProduitId = item.ProduitId,
                    Remise = item.Remise,
                    Count = item.Count,
                    Name = await db.Produits.Where(m => m.Id == item.ProduitId)
                                    .Select(m => m.Name).FirstOrDefaultAsync(),
                    Description = item.Description,
                    Price = item.Price,
                    Tax = item.Tax
                };

                await db.BillDetails.AddAsync(billDetail);
            }

            db.ShooppingCarts.RemoveRange(shoopingcartList);
            await db.SaveChangesAsync();

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult AddToCart(string id)
        {
            List<int> ListproductInShoppingCart = db.ShooppingCarts
                                          .Where(m => m.ApplicationUserId == id && m.NumBill != null)
                                          .Select(m => m.ProduitId).ToList();

            IQueryable<Produit> Products = from s in db.Produits
                                           where !(ListproductInShoppingCart.Contains(s.Id))
                                           select s;

            BillDetailsVM.ProductsList = Products.ToList();
            BillDetailsVM.ShooppingCart = new ShooppingCart();
            BillDetailsVM.ShooppingCart.ApplicationUserId = id;

            BillDetailsVM.Bill = new Bill()
            {
                NumBill = ("#Fact/" + DateTime.Now.ToFileTime().ToString()).Substring(1, 18)

            };
            return View(BillDetailsVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToCart(BillDetailsViewModel model)
        {
            BillDetailsVM.ShooppingCart = new ShooppingCart()
            {
                ApplicationUserId = model.ShooppingCart.ApplicationUserId,
                ProduitId = model.BillDetail.ProduitId,
                Description = model.ShooppingCart.Description,
                NumProposal = null,
                NumBill = model.Bill.NumBill,
                Count = model.ShooppingCart.Count,
                Price = model.ShooppingCart.Price,
                Tax = model.ShooppingCart.Tax,
                Remise = model.ShooppingCart.Remise,
                Montant = model.ShooppingCart.Montant
            };

            await db.ShooppingCarts.AddAsync(BillDetailsVM.ShooppingCart);
            await db.SaveChangesAsync();
            return RedirectToAction("Create", "Bills", new { id = model.ShooppingCart.ApplicationUserId });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveCart(int productId)
        {
            var shoopingCart = await db.ShooppingCarts.Where(m => m.ProduitId == productId && m.NumBill != null).FirstOrDefaultAsync();

            if (shoopingCart != null)
            {
                db.ShooppingCarts.Remove(shoopingCart);
                await db.SaveChangesAsync();
            }

            return RedirectToAction("Create", new { id = shoopingCart.ApplicationUserId });
        }

        //////////
        /// Modifier une facture
        ////
        ///
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bill bill = await db.Bills.FindAsync(id);
            double total=0, remise = 0;
  
            var billdetails = await db.BillDetails.Where(m => m.BillId == id).ToListAsync();

            foreach (var item in billdetails)
            {
                total += (item.Price * item.Count);
                remise += item.Remise;
            }

            double totalAmountPaid = 0;
            List<double> listAmountPaid = await db.Receipts.Include(m => m.Bill).Where(m => m.BillId == id)
                                    .Select(m => m.Montant).ToListAsync();

            foreach (var amount in listAmountPaid)
            {
                totalAmountPaid += amount;
            }

            if (bill == null)
            {
                return NotFound();
            }

            bill.Paid = totalAmountPaid;
            bill.BillTotalOrginal = total;
            bill.BillTotal = bill.BillTotalOrginal - remise;
            UserBillDetailViewModel UserBillDetailVM = new UserBillDetailViewModel()
            {
                Bill = bill,
                ApplicationUser = await db.ApplicationUsers.Where(m => m.Id == bill.UserId).FirstOrDefaultAsync(),
                BillDetailsList = await db.BillDetails.Include(m => m.Bill).Where(m => m.BillId == bill.Id).ToListAsync(),
                CreditNoteList = await db.CreditNotes.Include(m => m.Bill).Where(m => m.BillId == bill.Id).ToListAsync(),
                ReceiptList = await db.Receipts.Include(m => m.Bill).Where(m => m.BillId == bill.Id).ToListAsync()
            };

            return View(UserBillDetailVM);
        }

        //////////
        /// Modifier le contenu de la facture
        ////
        ///

        public async Task<IActionResult> Plus(int id, UserBillDetailViewModel model)
        {
            var billDetail = await db.BillDetails.Where(m => m.ProduitId == id
                                && m.BillId == model.Bill.Id).FirstOrDefaultAsync();

            billDetail.Count++;
            await db.SaveChangesAsync();
            return RedirectToAction("Edit", new { id = billDetail.BillId });
        }

        public async Task<IActionResult> Minus(int id, UserBillDetailViewModel model)
        {
            var billDetail = await db.BillDetails.Where(m => m.ProduitId == id
                                && m.BillId == model.Bill.Id).FirstOrDefaultAsync();
            if (billDetail != null)
            {
                if (billDetail.Count > 1)
                {
                    billDetail.Count--;
                    await db.SaveChangesAsync();
                }
            }

            return RedirectToAction("Edit", new { id = billDetail.BillId });
        }

        public async Task<IActionResult> Remove(int id, UserBillDetailViewModel model)
        {
            var billDetail = await db.BillDetails.Where(m => m.ProduitId == id
                                && m.BillId == model.Bill.Id).FirstOrDefaultAsync();

            if (billDetail != null)
            {
                db.BillDetails.Remove(billDetail);
                await db.SaveChangesAsync();
            }

            return RedirectToAction("Edit", new { id = billDetail.BillId });

        }

        [HttpGet]
        public IActionResult AddProducts(int id)
        {
            BillDetail billDetail = new BillDetail()
            {
                BillId = id,
                Count = 1,
                Remise = 0
            };
            List<int> ListproductInBillDetails = db.BillDetails
                                          .Where(m => m.BillId == id)
                                          .Select(m => m.ProduitId).ToList();

            IQueryable<Produit> Products = from s in db.Produits
                                           where !(ListproductInBillDetails.Contains(s.Id))
                                           select s;
            BillDetailsVM.ProductsList = Products.ToList();
            BillDetailsVM.BillDetail = billDetail;

            return View(BillDetailsVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProducts(BillDetailsViewModel model)
        {
            string nameProduct = await db.Produits.Where(m => m.Id == model.BillDetail.ProduitId)
                                .Select(m => m.Name).FirstOrDefaultAsync();

            BillDetailsVM.BillDetail = new BillDetail()
            {
                BillId = model.BillDetail.BillId,
                ProduitId = model.BillDetail.ProduitId,
                Remise = model.BillDetail.Remise,
                Count = model.BillDetail.Count,
                Name = nameProduct,
                Description = model.BillDetail.Description,
                Price = model.BillDetail.Price,
                Tax = model.BillDetail.Tax
            };

            await db.BillDetails.AddAsync(BillDetailsVM.BillDetail);
            await db.SaveChangesAsync();
            return RedirectToAction("Edit", new { id = model.BillDetail.BillId });
        }



        //////////
        /// Detail de Facture
        ////

        public async Task<IActionResult> Details(int id)
        {
            var bill = await db.Bills.FindAsync(id);
            UserBillDetailViewModel UserBillDetailVM = new UserBillDetailViewModel()
            {
                Bill = bill,
                ApplicationUser = await db.ApplicationUsers.Where(m => m.Id == bill.UserId).FirstOrDefaultAsync(),
                BillDetailsList = await db.BillDetails.Where(m => m.BillId == bill.Id).ToListAsync(),
                CreditNoteList = await db.CreditNotes.Where(m => m.BillId == bill.Id).ToListAsync(),
                ReceiptList = await db.Receipts.Where(m => m.BillId == bill.Id).ToListAsync()
            };

            return View(UserBillDetailVM);
        }


        //////////
        /// Supprimer une facture
        ////

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            Bill model = db.Bills.Find(id);
            if (model == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Erreur lors de la suppression !",
                    html = Helper.RenderRazorViewToString(this, "_ViewAll", await db.Bills.Include(m => m.ApplicationUser).ToListAsync())
                });
            }
            db.Bills.Remove(model);
            await db.SaveChangesAsync();
            return Json(new
            {
                success = true,
                message = "Facture supprimé !",
                html = Helper.RenderRazorViewToString(this, "_ViewAll", await db.Bills.Include(m => m.ApplicationUser).ToListAsync())
            });
        }

        /// <summary>
        /// Delete Note de crédit
        /// </summary>

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteNote(int? noteId)
        {

            CreditNote creditNote = db.CreditNotes.Find(noteId);

            var bill = await db.Bills.Where(m => m.Id == creditNote.BillId).FirstOrDefaultAsync();

            UserBillDetailViewModel UserBillDetailVM = new UserBillDetailViewModel()
            {
                Bill = bill,
                ApplicationUser = await db.ApplicationUsers.Where(m => m.Id == bill.UserId).FirstOrDefaultAsync(),
                BillDetailsList = await db.BillDetails.Where(m => m.BillId == bill.Id).ToListAsync(),
                CreditNoteList = await db.CreditNotes.Where(m => m.BillId == bill.Id).ToListAsync(),
                ReceiptList = await db.Receipts.Where(m => m.BillId == bill.Id).ToListAsync()
            };

            if (creditNote == null)
            {
                return Json(new { success = false, message = "Erreur lors de la suppression !", html = Helper.RenderRazorViewToString(this, "Edit", UserBillDetailVM) });
            }

            db.CreditNotes.Remove(creditNote);
            await db.SaveChangesAsync();
            return Json(new { success = true, message = "Note de crédit supprimé !", html = Helper.RenderRazorViewToString(this, "Edit", UserBillDetailVM) });
        }

        // Send Email
        public async Task<IActionResult> SendBill(int? id)
        {
            var bill = await db.Bills.FindAsync(id);
            var userId = await db.Bills.Where(m => m.Id == id)
                                 .Select(m => m.UserId).SingleOrDefaultAsync();

            var user = await db.ApplicationUsers.Where(m => m.Id == userId).FirstOrDefaultAsync();

            await _emailSender.SendEmailAsync(user.Email, "Confirmer votre Facture",
                                "Bonjour : " + user.FirstName + " " + user.LastName + "<br/>" +
                                "Vous avez une nouvelle facture de la part de AppliTaxi <br/>" +
                                "Cliquer sur le lien si dessous pour voir les détails de votre facture <br/>" +
                                "https://localhost:44300/Customer/Bills/Overview/" + id + "<br/>" + "<hr>" +
                                "<div class='col-md-12'><div class='row ml-1'>" +
                                "<span><img class='pb-2' " +
                                "src='https://is1-ssl.mzstatic.com/image/thumb/Purple118/v4/1b/29/f2/1b29f20e-3004-5715-d070-5356ad545b21/source/512x512bb.jpg' " +
                                "style='width:200px; height:150px;'/></span>" +
                                "<p>28 avenue de la résistance <br />91700 Sainte - Genevièves - des - bois <br />" +
                                "<b> SIRET :</ b > 83138505900017 <br/>France</p>" +
                                "</div></div>");

            bill.Status = SD.StatusSend;
            db.Bills.Update(bill);
            await db.SaveChangesAsync();

            return RedirectToAction("Details", new { id = id });
        }


        //Overview

        public async Task<IActionResult> Overview(int id)
        {
            var bill = await db.Bills.FindAsync(id);
            UserBillDetailViewModel UserBillDetailVM = new UserBillDetailViewModel()
            {
                Bill = bill,
                ApplicationUser = await db.ApplicationUsers.Where(m => m.Id == bill.UserId).FirstOrDefaultAsync(),
                BillDetailsList = await db.BillDetails.Where(m => m.BillId == bill.Id).ToListAsync(),
                CreditNoteList = await db.CreditNotes.Where(m => m.BillId == bill.Id).ToListAsync()
            };

            return View(UserBillDetailVM);
        }

        public async Task<IActionResult> Confirm(int id)
        {
            var bill = await db.Bills.FindAsync(id);
            bill.Status = SD.StatusAccepted;
            db.Bills.Update(bill);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        //// Get User By Id
        //
        public string GetUserId()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            return claim.Value;
        }
    }
}
