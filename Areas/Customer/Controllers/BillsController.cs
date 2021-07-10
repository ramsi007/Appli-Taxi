using Appli_Taxi.Data;
using Appli_Taxi.Models;
using Appli_Taxi.Models.ViewModels;
using Appli_Taxi.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Appli_taxi.Areas.Customer.Controllers
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

        ProposalCartViewModel ProposalCartVM = new ProposalCartViewModel();
        UserBillDetailViewModel UserBillDetailsVM = new UserBillDetailViewModel();

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

        [Authorize(Roles = SD.ManagerUser + "," + SD.VendorUser)]
        public async Task<IActionResult> Create(string id)
        {
            Bill bill = new Bill();
            bill.NumBill = ("#Fact/" + DateTime.Now.ToFileTime().ToString()).Substring(1,18);
            bill.DueDate = Convert.ToDateTime(DateTime.Now.ToString("dd-MMMM-yyyy"));
            bill.IssueDate = Convert.ToDateTime(DateTime.Now.ToString("dd-MMMM-yyyy"));
            bill.UserId = id;

            UserProposalViewModel UserProposalVM = new UserProposalViewModel();
            UserProposalVM.Bill = bill;
            var ListCartFromDb = await db.ShooppingCarts.Where(m => m.ApplicationUserId == id && m.NumBill != null).ToListAsync();

            if (ListCartFromDb.Count > 0)
            {
                foreach (var cart in ListCartFromDb)
                {
                    bill.BillTotalOrginal += cart.Montant;
                    bill.Remise += Convert.ToDouble(cart.Remise);
                }
                bill.BillTotal += Math.Round((bill.BillTotalOrginal - bill.Remise),2);
            }

            if (id == null)
            {
                if (User.IsInRole(SD.ManagerUser))
                {
                    UserProposalVM.ListUsers = await db.ApplicationUsers.Where(m => m.UserRole != SD.EmployeeUser).ToListAsync();
                }
                else if (User.IsInRole(SD.VendorUser))
                {
                    UserProposalVM.ListUsers = await db.ApplicationUsers.Where(m => m.UserRole.Equals(SD.ManagerUser)).ToListAsync();
                }
            }
            else
            {
                    UserProposalVM.ListUsers = await db.ApplicationUsers.Where(m => m.Id == id).ToListAsync();
            }
            UserProposalVM.ListShoopingCart = ListCartFromDb;

            List<string> Users = new List<string>();
            //ApplicationUser ListUsers = new ApplicationUser();


            Users = db.ShooppingCarts.Where(m => m.NumBill != null).Select(m => m.ApplicationUserId).ToList();
            IQueryable<ApplicationUser> ListUsers;

            if (User.IsInRole(SD.VendorUser))
            {
                    ListUsers = from u in db.ApplicationUsers
                    where (Users.Contains(u.Id) && u.UserRole.Equals(SD.ManagerUser))
                    select u;
            }
            else
            {
                    ListUsers = from u in db.ApplicationUsers
                    where (Users.Contains(u.Id) && !u.UserRole.Equals(SD.ManagerUser))
                    select u;
            }


            HttpContext.Session.SetInt32(SD.ShoopingCartCount, ListUsers.Count());
            return View(UserProposalVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserProposalViewModel model)
        {
            var user = new ApplicationUser();
            if(User.IsInRole(SD.VendorUser))
            {
                 user = await db.ApplicationUsers.Where(m => m.Id == model.Bill.UserId
                                    && m.UserRole.Equals(SD.ManagerUser)).FirstOrDefaultAsync();
            }else
            {
                 user = await db.ApplicationUsers.Where(m => m.Id == model.Bill.UserId
                            && !m.UserRole.Equals(SD.ManagerUser)).FirstOrDefaultAsync();
            }

            var shoopingcartList = await db.ShooppingCarts.Where(m => m.ApplicationUserId 
                                    == user.Id && m.NumBill != null).ToListAsync();
                                

            Bill bill = new Bill();

            foreach (var cart in shoopingcartList)
            {
                bill.BillTotalOrginal += cart.Montant;
                bill.Remise += Convert.ToDouble(cart.Remise);
            }
            bill.BillTotal += Math.Round((bill.BillTotalOrginal - bill.Remise), 2);
            
            bill.UserId = user.Id;
            bill.DueDate = model.Bill.DueDate;
            bill.IssueDate = model.Bill.IssueDate;
            bill.Status = SD.StatusNotPaid;
            bill.PhoneNumber = user.PhoneNumber;
            bill.BillType = model.Bill.BillType;
            bill.NumBill = model.Bill.NumBill;
            bill.Paid = 0;
            bill.Rest = 0;
            await db.Bills.AddAsync(bill);
            await db.SaveChangesAsync();


            foreach (var item in shoopingcartList)
            {
                BillDetail billDetail = new BillDetail()
                {
                    BillId = bill.Id,
                    ProduitId = item.ProduitId,
                    Remise = Convert.ToDouble(item.Remise),
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
        public async Task<IActionResult> AddToCart(string id, int billId)
        {
            List<int> ListproductInShoppingCart = new List<int>();

            if (billId == 0)
            {
                ListproductInShoppingCart = db.ShooppingCarts
                                             .Where(m => m.ApplicationUserId == id && m.NumBill != null)
                                             .Select(m => m.ProduitId).ToList();
            }
            else
            {
                ListproductInShoppingCart = db.BillDetails
                                .Where(m => m.BillId == billId).Select(m => m.ProduitId).ToList();
                Bill bill = await db.Bills.Where(m => m.Id == billId).FirstOrDefaultAsync();
                ProposalCartVM.Bill = bill;
            }
            IQueryable<Produit> Products = from s in db.Produits
                                           where !(ListproductInShoppingCart.Contains(s.Id))
                                           select s;

            ProposalCartVM.ListProduct = Products.ToList();
            ProposalCartVM.ApplicationUser = await db.ApplicationUsers.Where(m => m.Id == id).FirstOrDefaultAsync();

            ProposalCartVM.ShooppingCart = new ShooppingCart()

            {
                ApplicationUserId = id,
            };

            return View(ProposalCartVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToCart(ProposalCartViewModel model)
        {

            var product = await db.Produits.Where(m => m.Id == model.ShooppingCart.ProduitId)
                            .FirstOrDefaultAsync();
            var tax = await db.Taxes.Where(m => m.Id == product.TaxId).FirstOrDefaultAsync();
            var total = ((model.ShooppingCart.Count * product.SalePrice) + ((model.ShooppingCart.Count * product.SalePrice) * tax.Discount) / 100);
            if (model.Bill.Id == 0)
            {
                ShooppingCart cart = new ShooppingCart()
                {
                    ApplicationUserId = model.ShooppingCart.ApplicationUserId,
                    ProduitId = product.Id,
                    Description = model.ShooppingCart.Description,
                    Count = model.ShooppingCart.Count,
                    NumProposal = null,
                    NumBill = ("#Fact/" + DateTime.Now.ToFileTime().ToString()).Substring(1, 18),
                    Price = product.SalePrice,
                    Tax = tax.Discount,
                    Remise = model.ShooppingCart.Remise,
                    Montant = Math.Round(total,2)
                };
                await db.ShooppingCarts.AddAsync(cart);
                await db.SaveChangesAsync();
                return RedirectToAction("Create", new { id = model.ShooppingCart.ApplicationUserId });
            }
            else
            {
                BillDetail billDetail = new BillDetail()
                {
                    BillId = model.Bill.Id,
                    ProduitId = product.Id,
                    Remise = Convert.ToDouble(model.ShooppingCart.Remise),
                    Count = model.ShooppingCart.Count,
                    Name = product.Name,
                    Description = model.ShooppingCart.Description,
                    Price = product.SalePrice,
                    Tax = tax.Discount
                };
                await db.BillDetails.AddAsync(billDetail);
                await db.SaveChangesAsync();
                return RedirectToAction("Edit", new { billId = model.Bill.Id });
            }
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
        [Authorize(Roles = SD.ManagerUser)]
        public async Task<IActionResult> Edit(int billId)
        {
            Bill bill = await db.Bills.FindAsync(billId);
            if(bill != null)
            {
                UpdateBill(billId);
            }
            UserBillDetailViewModel UserBillDetailVM = new UserBillDetailViewModel()
            {
                Bill = bill,
                ApplicationUser = await db.ApplicationUsers.Where(m => m.Id == bill.UserId).FirstOrDefaultAsync(),
                BillDetailsList = await db.BillDetails.Include(m => m.Bill).Where(m => m.BillId == bill.Id).ToListAsync(),
                CreditNoteList = await db.CreeditNotes.Include(m => m.Bill).Where(m => m.BillId == bill.Id).ToListAsync(),
                ReceiptList = await db.Receipts.Include(m => m.Bill).Where(m => m.BillId == bill.Id).ToListAsync()
            };

            
            return View(UserBillDetailVM);
        }

        //////////
        /// Modifier le contenu de la facture
        ////
        ///

        //Plus
        public async Task<IActionResult> Plus(int id, int productId, int cartId, UserBillDetailViewModel model)
        {
            if(id >0)
            {
                var billDetail = await db.BillDetails.Where(m => m.ProduitId == id
                                    && m.BillId == model.Bill.Id).FirstOrDefaultAsync();
            
                billDetail.Count++;
                UpdateBill(model.Bill.Id);
                await db.SaveChangesAsync();
                return RedirectToAction("Edit", new { billId = billDetail.BillId });
            }
            else
            {
                var shoopingCart = await db.ShooppingCarts.Where(m => m.ProduitId == productId
                                    && m.Id == cartId).FirstOrDefaultAsync();

                shoopingCart.Count++;
                shoopingCart.Montant = Math.Round(((shoopingCart.Count * shoopingCart.Price) 
                                        + ((shoopingCart.Count * shoopingCart.Price)*shoopingCart.Tax/100)),2);
                await db.SaveChangesAsync();
                return RedirectToAction("ShoopingCart");
            }
        }

        //Moins
        public async Task<IActionResult> Minus(int id, int productId, int cartId, UserBillDetailViewModel model)
        {
            if (id > 0)
            {
                var billDetail = await db.BillDetails.Where(m => m.ProduitId == id
                                    && m.BillId == model.Bill.Id).FirstOrDefaultAsync();

                if (billDetail != null)
                {
                    if (billDetail.Count > 1)
                    {
                        billDetail.Count--;
                        UpdateBill(model.Bill.Id);
                        await db.SaveChangesAsync();
                    }
                }
                return RedirectToAction("Edit", new { billId = billDetail.BillId });
            }
            else
            {
                var shoopingCart = await db.ShooppingCarts.Where(m => m.ProduitId == productId
                                    && m.Id == cartId).FirstOrDefaultAsync();

                shoopingCart.Count--;
                shoopingCart.Montant = Math.Round(((shoopingCart.Count * shoopingCart.Price)
                                        + ((shoopingCart.Count * shoopingCart.Price) * shoopingCart.Tax / 100)), 2);
                await db.SaveChangesAsync();
                return RedirectToAction("ShoopingCart");
            }
        }

        //Remove product
        public async Task<IActionResult> Remove(int id, int productId, int cartId,UserBillDetailViewModel model)
        {
            if(id>0)
            {
                var billDetail = await db.BillDetails.FindAsync(id);
                db.BillDetails.Remove(billDetail);
                await db.SaveChangesAsync();

                return RedirectToAction("Edit", new { billId = billDetail.BillId });
            }
            else
            {
                var shoopingCart = await db.ShooppingCarts.FindAsync(cartId);
                db.ShooppingCarts.Remove(shoopingCart);
                await db.SaveChangesAsync();

                return RedirectToAction("ShoopingCart");
            }
        }

        //////////
        /// Detail de Facture
        ////

        public async Task<IActionResult> Details(int id)
        {
            var bill = await db.Bills.FindAsync(id);
            UpdateBill(id);

            UserBillDetailViewModel UserBillDetailVM = new UserBillDetailViewModel()
            {
                Bill = bill,
                ApplicationUser = await db.ApplicationUsers.Where(m => m.Id == bill.UserId).FirstOrDefaultAsync(),
                BillDetailsList = await db.BillDetails.Where(m => m.BillId == bill.Id).ToListAsync(),
                CreditNoteList = await db.CreeditNotes.Where(m => m.BillId == bill.Id).ToListAsync(),
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
        /// <returns></returns>
        /// 
        public async Task<IActionResult> RemoveReceipt(int receiptId)
        {
            var model = await db.Receipts.FindAsync(receiptId);
            return View(model);    
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveReceipt(Receipt receipt)
        {
            Receipt model = await db.Receipts.FindAsync(receipt.Id);
            Bill bill = await db.Bills.Where(m => m.Id == model.BillId).FirstOrDefaultAsync();
            UserBillDetailViewModel UserBillDetailVM = new UserBillDetailViewModel()
            {
                Bill = bill,
                ApplicationUser = await db.ApplicationUsers.Where(m => m.Id == bill.UserId).FirstOrDefaultAsync(),
                BillDetailsList = await db.BillDetails.Include(m => m.Bill).Where(m => m.BillId == bill.Id).ToListAsync(),
                CreditNoteList = await db.CreeditNotes.Include(m => m.Bill).Where(m => m.BillId == bill.Id).ToListAsync(),
                ReceiptList = await db.Receipts.Include(m => m.Bill).Where(m => m.BillId == bill.Id).ToListAsync()
            };
            if (model == null)
            {
                return Json(new { success = false, message = "Erreur lors de la suppression !", html = Helper.RenderRazorViewToString(this, "Edit", UserBillDetailVM) });
            }
            db.Receipts.Remove(model);
            bill.Status = SD.StatusPrePaid;
            db.Bills.Update(bill);
            await db.SaveChangesAsync();

            return Json(new 
            { 
                success = true, 
                message = "reçu supprimé !",
                isValid = true,
                html = Helper.RenderRazorViewToString(this, "Details", UserBillDetailVM) });
        }


        public async Task<IActionResult> RemoveNote(int noteId)
        {
            var model = await db.CreeditNotes.FindAsync(noteId);
            return View(model);
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveNote(CreeditNote note)
        {
            CreeditNote model = await db.CreeditNotes.FindAsync(note.Id);
            Bill bill = await db.Bills.Where(m => m.Id == model.BillId).FirstOrDefaultAsync();
            UserBillDetailViewModel UserBillDetailVM = new UserBillDetailViewModel()
            {
                Bill = bill,
                ApplicationUser = await db.ApplicationUsers.Where(m => m.Id == bill.UserId).FirstOrDefaultAsync(),
                BillDetailsList = await db.BillDetails.Include(m => m.Bill).Where(m => m.BillId == bill.Id).ToListAsync(),
                CreditNoteList = await db.CreeditNotes.Include(m => m.Bill).Where(m => m.BillId == bill.Id).ToListAsync(),
                ReceiptList = await db.Receipts.Include(m => m.Bill).Where(m => m.BillId == bill.Id).ToListAsync()
            };
            if (model == null)
            {
                return Json(new { success = false, message = "Erreur lors de la suppression !", html = Helper.RenderRazorViewToString(this, "Edit", UserBillDetailVM) });
            }
            db.CreeditNotes.Remove(model);
            bill.Status = SD.StatusPrePaid;
            db.Bills.Update(bill);
            await db.SaveChangesAsync();

            return Json(new
            {
                success = true,
                message = "note de crédit supprimé !",
                isValid = true,
                html = Helper.RenderRazorViewToString(this, "Details", UserBillDetailVM)
            });
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
                                "https://localhost:44331/Customer/Bills/Overview/" + id + "<br/>" + "<hr>" +
                                "<div class='col-md-12'><div class='row ml-1'>" +
                                "<span><img class='pb-2' " +
                                "src='https://is1-ssl.mzstatic.com/image/thumb/Purple118/v4/1b/29/f2/1b29f20e-3004-5715-d070-5356ad545b21/source/512x512bb.jpg' " +
                                "style='width:200px; height:150px;'/></span>" +
                                "<p>28 avenue de la résistance <br />91700 Sainte - Genevièves - des - bois <br />" +
                                "<b> SIRET :</ b > 83138505900017 <br/>France</p>" +
                                "</div></div>");

            if(bill.Status.Equals(SD.StatusNotPaid))
            {
                bill.Status = SD.StatusSend;
                db.Bills.Update(bill);
                await db.SaveChangesAsync();

            }

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
                CreditNoteList = await db.CreeditNotes.Where(m => m.BillId == bill.Id).ToListAsync()
            };

            return View(UserBillDetailVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Overview(UserBillDetailViewModel model, string stripeToken)
        {
            var bill = await db.Bills.FindAsync(model.Bill.Id);
            var options = new Stripe.ChargeCreateOptions
            {
                Amount = Convert.ToInt32(bill.Rest * 100),
                Currency = "eur",
                Description = "Order ID : " + model.Bill.Id,
                Source = stripeToken
            };

            var service = new ChargeService();
            Charge charge = service.Create(options);

            if (charge.BalanceTransactionId == null)
            {
                bill.Status = SD.StatusDeclined;
            }
            else
            {
                bill.TransactionId = charge.BalanceTransactionId;
            }

            if (charge.Status.ToLower() == "succeeded")
            {
                bill.Status = SD.StatusPaid;
                bill.Paid = bill.Paid + bill.Rest;
                bill.Rest = 0;
            }
            else
            {
                bill.Status = SD.StatusDeclined;
            }

            db.Bills.Update(bill);
            await db.SaveChangesAsync();


            return RedirectToAction("Details", new { id = model.Bill.Id });
        }


        public async Task<IActionResult> Confirm(int id)
        {
            var bill = await db.Bills.FindAsync(id);
            bill.Status = SD.StatusAccepted;
            db.Bills.Update(bill);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        /// Shopping Cart ///

        [Authorize(Roles = SD.ManagerUser + "," + SD.VendorUser)]
        public async Task<IActionResult> ShoopingCart()
        {

            List<string> Users = new List<string>();
            List<ShooppingCart> billsInShooppingCart = new List<ShooppingCart>();

            Users = db.ShooppingCarts.Where(m=>m.NumBill != null).Select(m => m.ApplicationUserId).ToList();

            IQueryable<ApplicationUser> ListUsers = from u in db.ApplicationUsers
                                                    where (Users.Contains(u.Id))
                                                    select u;
            IList<ShoppingCartViewModel> ListShoppingCartVM = new List<ShoppingCartViewModel>();
           
            foreach (var user in ListUsers)
            {
                if (User.IsInRole(SD.VendorUser))
                {
                    billsInShooppingCart = await db.ShooppingCarts.Where(m => m.ApplicationUserId == user.Id && m.NumBill != null 
                                            && user.UserRole.Equals(SD.ManagerUser)).ToListAsync();
                }
                else
                {
                    billsInShooppingCart = await db.ShooppingCarts.Where(m => m.ApplicationUserId == user.Id && m.NumBill != null
                                           && !user.UserRole.Equals(SD.ManagerUser)).ToListAsync();
                }

                ShoppingCartViewModel ShoppingCartVM = new ShoppingCartViewModel()
                {
                    ListBilllShooppingCarts = billsInShooppingCart,
                    User = await db.ApplicationUsers.FindAsync(user.Id)
                };

                ShoppingCartVM.ListProducts = await db.Produits.ToListAsync();
                ListShoppingCartVM.Add(ShoppingCartVM);
            }

            return View(ListShoppingCartVM);
        }


        //// Get User By Id
        //
        public string GetUserId()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            return claim.Value;
        }

        /// <summary>
        /// 
        /// 
        /// </summary>

        public void UpdateBill(int? id)
        {
            
            var bill = db.Bills.Find(id);
            if (bill.Status != SD.StatusPaid)
            {
                bill.BillTotalOrginal = 0; bill.Remise = 0;
                var ListProductInBillDetails =  db.BillDetails.Where(m => m.BillId == id).ToList();


                double totalAmountPaid = 0, totalNoteAmount = 0;
                List<double> listAmountPaid =  db.Receipts.Include(m => m.Bill).Where(m => m.BillId == id)
                                        .Select(m => m.Montant).ToList();

                List<double> listCreditNotes =  db.CreeditNotes.Include(m => m.Bill).Where(m => m.BillId == id)
                            .Select(m => m.Montant).ToList();
                foreach (var amount in listAmountPaid)
                {
                    totalAmountPaid += amount;
                }

                foreach (var note in listCreditNotes)
                {
                    totalNoteAmount += note;
                }


                foreach (var product in ListProductInBillDetails)
                {
                    bill.BillTotalOrginal += Math.Round((product.Count * product.Price) + ((product.Count * product.Price)*product.Tax)/100,2);
                    bill.Remise += Convert.ToDouble(product.Remise);
                }
                bill.BillTotal = Math.Round((bill.BillTotalOrginal - bill.Remise),2);
                bill.Paid = totalAmountPaid;
                bill.Rest = bill.BillTotal - totalNoteAmount - bill.Paid;

                if (bill.Paid == 0 && bill.Rest > 0)
                {
                    bill.Status = SD.StatusNotPaid;
                }
                else if (bill.Paid > 0 && bill.Rest > 0)
                {
                    bill.Status = SD.StatusPrePaid;
                }
                else if (bill.Paid > 0 && bill.Rest == 0)
                {
                    bill.Status = SD.StatusPaid;
                }

                db.Bills.Update(bill);
                db.SaveChanges();
            }

        }

    }
}
