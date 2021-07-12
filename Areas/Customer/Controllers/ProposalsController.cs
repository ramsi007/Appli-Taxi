using Appli_Taxi.Models.ViewModels;
using Appli_Taxi.Data;
using Appli_Taxi.Models;
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
using Microsoft.AspNetCore.Http;

namespace Appli_Taxi.Areas.Customer.Controllers
{

    [Authorize]
    [Area("Customer")]
    public class ProposalsController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly IEmailSender _emailSender;
        [TempData]
        public string StatusMessage { get; set; }

        public ProposalsController(ApplicationDbContext _db, IEmailSender emailSender)
        {
            this.db = _db;
            _emailSender = emailSender;
        }

        ProposalCartViewModel ProposalCartVM = new ProposalCartViewModel();

        public async Task<IActionResult> Index()
        {
            var ListProposal = new List<Proposal>();
            if (User.IsInRole(SD.ManagerUser))
            {
                ListProposal = await db.Proposals.Include(m => m.ApplicationUser).ToListAsync();
            }
            else
            {
                ListProposal = await db.Proposals.Include(m => m.ApplicationUser)
                       .Where(m => m.UserId == GetUserId()).ToListAsync();
            }

            return View(ListProposal);
        }

        [Authorize(Roles = SD.ManagerUser)]
        [HttpGet]
        public async Task<IActionResult> Create(string id)
        {
            Proposal proposal = new Proposal();
            proposal.NumProposal = ("#Prop/" + DateTime.Now.ToFileTime().ToString()).Substring(1, 18);
            proposal.ProposalDate = Convert.ToDateTime(DateTime.Now.ToString("dd-MMMM-yyyy"));
            proposal.UserId = id;

            UserProposalViewModel UserProposalVM = new UserProposalViewModel();
            UserProposalVM.Proposal = proposal;
            var ListCartFromDb = await db.ShooppingCarts.Where(m => m.ApplicationUserId == id && m.NumProposal != null).ToListAsync();

            if (ListCartFromDb.Count > 0)
            {
                foreach (var cart in ListCartFromDb)
                {
                    proposal.ProposalTotalOrginal += Math.Round(((cart.Count * cart.Price) + ((cart.Count * cart.Price) * cart.Tax) / 100), 2); ;
                    proposal.Remise += Convert.ToDouble(cart.Remise);
                }
                proposal.Remise = Math.Round(proposal.Remise, 2);
                proposal.ProposalTotal += Math.Round((proposal.ProposalTotalOrginal - proposal.Remise), 2);
            }

            if (id == null)
            {
                if (User.IsInRole(SD.ManagerUser))
                {
                    UserProposalVM.ListUsers = await db.ApplicationUsers.Where(m => m.UserRole.Equals(SD.CustomerUser)).ToListAsync();
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


            Users = db.ShooppingCarts.Where(m=>m.NumProposal!=null).Select(m => m.ApplicationUserId).ToList();

            IQueryable<ApplicationUser> ListUsers = from u in db.ApplicationUsers
                                                    where (Users.Contains(u.Id))
                                                    select u;

            HttpContext.Session.SetInt32(SD.ShoopingCartCount, ListUsers.Count());
            //



            return View(UserProposalVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserProposalViewModel model)
        {
            var user = await db.ApplicationUsers.Where(m => m.Id == model.Proposal.UserId).FirstOrDefaultAsync();
            var shoopingcartList = await db.ShooppingCarts.Where(m => m.ApplicationUserId
                                 == user.Id && m.NumProposal != null).ToListAsync();

            Proposal proposal = new Proposal();

            foreach (var cart in shoopingcartList)
            {
                proposal.ProposalTotalOrginal += Math.Round(((cart.Count * cart.Price) + ((cart.Count * cart.Price) * cart.Tax) / 100), 2);
                proposal.Remise += Convert.ToDouble(cart.Remise);
                proposal.ProposalTotal += Math.Round(cart.Montant, 2) - proposal.Remise;
            }

            proposal.UserId = user.Id;
            proposal.ProposalDate = model.Proposal.ProposalDate;
            proposal.Status = SD.StatusInProcess;
            proposal.PhoneNumber = user.PhoneNumber;
            proposal.PoposalType = model.Proposal.PoposalType;
            proposal.NumProposal = model.Proposal.NumProposal;

            await db.Proposals.AddAsync(proposal);
            await db.SaveChangesAsync();


            foreach (var item in shoopingcartList)
            {
                ProposalDetail proposalDetail = new ProposalDetail()
                {
                    ProposalId = proposal.Id,
                    ProduitId = item.ProduitId,
                    Remise = Math.Round(Convert.ToDouble(item.Remise), 2),
                    Count = item.Count,
                    Name = await db.Produits.Where(m => m.Id == item.ProduitId)
                                    .Select(m => m.Name).FirstOrDefaultAsync(),
                    Description = item.Description,
                    Price = item.Price,
                    Tax = item.Tax
                };

                await db.ProposalDetails.AddAsync(proposalDetail);

            }
            db.ShooppingCarts.RemoveRange(shoopingcartList);
            await db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        /// Add To Cart
        [HttpGet]
        public async Task<IActionResult> AddToCart(string id, int proposalId)
        {
            List<int> ListproductInShoppingCart = new List<int>();

            if (proposalId == 0)
            {
                ListproductInShoppingCart = db.ShooppingCarts
                                             .Where(m => m.ApplicationUserId == id && m.NumProposal != null)
                                             .Select(m => m.ProduitId).ToList();
            }
            else
            {
                ListproductInShoppingCart = db.ProposalDetails
                                .Where(m => m.ProposalId == proposalId).Select(m => m.ProduitId).ToList();
                Proposal proposal = await db.Proposals.Where(m => m.Id == proposalId).FirstOrDefaultAsync();
                ProposalCartVM.Proposal = proposal;
            }
            IQueryable<Produit> Products = from s in db.Produits
                                           where !(ListproductInShoppingCart.Contains(s.Id))
                                           select s;

            ProposalCartVM.ListProduct = Products.ToList();

            if(User.IsInRole(SD.VendorUser))
            {
                ProposalCartVM.ApplicationUser = await db.ApplicationUsers.Where(m => m.UserRole == SD.ManagerUser).FirstOrDefaultAsync();
            }
            else
            {
                ProposalCartVM.ApplicationUser = await db.ApplicationUsers.Where(m => m.Id == id).FirstOrDefaultAsync();
            }

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

            if (Convert.ToDouble(model.ShooppingCart.Remise) > total)
            {
                List<int> ListproductInShoppingCart = new List<int>();
                ListproductInShoppingCart = db.ShooppingCarts
                                                 .Where(m => m.ApplicationUserId == model.ShooppingCart.ApplicationUserId
                                                  && m.NumBill != null)
                                                 .Select(m => m.ProduitId).ToList();
                
                IQueryable<Produit> Products = from s in db.Produits
                                               where !(ListproductInShoppingCart.Contains(s.Id))
                                               select s;
                model.ListProduct = Products.ToList();
                model.ApplicationUser = await db.ApplicationUsers.Where(m => m.Id == model.ShooppingCart.ApplicationUserId).FirstOrDefaultAsync();
                model.StatusMessage = "Erreur : La remise saisi ne doit pas dépasser le montant total : " + total;
                return View(model);
            }else
            {
            if (model.Proposal.Id == 0)
            {
                ShooppingCart cart = new ShooppingCart()
                {
                    ApplicationUserId = model.ShooppingCart.ApplicationUserId,
                    ProduitId = product.Id,
                    Description = model.ShooppingCart.Description,
                    Count = model.ShooppingCart.Count,
                    NumProposal = ("#Prop/" + DateTime.Now.ToFileTime().ToString()).Substring(1, 18),
                    NumBill = null,
                    Price = product.SalePrice,
                    Tax = tax.Discount,
                    Remise = model.ShooppingCart.Remise,
                    Montant = Math.Round(total, 2)
                };
                await db.ShooppingCarts.AddAsync(cart);
                await db.SaveChangesAsync();
                return RedirectToAction("Create", new { id = model.ShooppingCart.ApplicationUserId });
            }
            else
            {
                ProposalDetail proposalDetail = new ProposalDetail()
                {
                    ProposalId = model.Proposal.Id,
                    ProduitId = product.Id,
                    Description = model.ShooppingCart.Description,
                    Count = model.ShooppingCart.Count,
                    Name = product.Name,
                    Price = product.SalePrice,
                    Tax = tax.Discount,
                    Remise = Convert.ToDouble(model.ShooppingCart.Remise),
                };
                await db.ProposalDetails.AddAsync(proposalDetail);
                await db.SaveChangesAsync();
                return RedirectToAction("Edit", new { proposalId = model.Proposal.Id });
            }
            }

        }

        /// Remove from Cart
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveCart(int productId, string userId)
        {
            var shoopingCart = await db.ShooppingCarts.Where(m => m.ProduitId == productId && m.ApplicationUserId == userId
                            && m.NumProposal != null).FirstOrDefaultAsync();

            if (shoopingCart != null)
            {
                db.ShooppingCarts.Remove(shoopingCart);
                await db.SaveChangesAsync();
            }

            return RedirectToAction("Create", new { id = shoopingCart.ApplicationUserId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete()
        {
            var model = await db.ShooppingCarts.ToListAsync();
            if (model == null)
            {
                return Json(new { success = false, message = "Erreur lors de la suppression !", html = Helper.RenderRazorViewToString(this, "_ViewAll", await db.Produits.ToListAsync()) });
            }
            db.ShooppingCarts.RemoveRange(model);
            await db.SaveChangesAsync();
            return Json(new { success = true, html = Helper.RenderRazorViewToString(this, "Index", await db.Proposals.ToListAsync()) });
        }


        //Ajax Json
        [HttpGet]
        public async Task<IActionResult> getPriceAndTax(int id)
        {
            var product = await db.Produits.Include(m => m.Tax).Where(m => m.Id == id).FirstOrDefaultAsync();

            return new JsonResult(product);
        }


        //Ajax Json
        [HttpGet]
        public async Task<IActionResult> getUserById(string id)
        {
            var user = await db.ApplicationUsers.Where(m => m.Id == id).FirstOrDefaultAsync();
            return new JsonResult(user);
        }

        /// Detail et aperçu de la proposition

        public async Task<IActionResult> Details(int proposalId)
        {
            var proposal = await db.Proposals.FindAsync(proposalId);
            UserProposalDetailsViewModel UserProDetailVM = new UserProposalDetailsViewModel()
            {
                Proposal = proposal,
                ApplicationUser = await db.ApplicationUsers.Where(m => m.Id == proposal.UserId).FirstOrDefaultAsync(),
                ProposalDetailsList = await db.ProposalDetails.Where(m => m.ProposalId == proposal.Id).ToListAsync()
            };

            return View(UserProDetailVM);
        }

        /// Edit proposition

        public async Task<IActionResult> Edit(int? proposalId)
        {
            if (proposalId == null)
            {
                return NotFound();
            }

            Proposal proposal = await db.Proposals.FindAsync(proposalId);

            if (proposal == null)
            {
                return NotFound();
            }

            UserProposalDetailsViewModel UserProDetailVM = new UserProposalDetailsViewModel()
            {
                Proposal = proposal,
                ApplicationUser = await db.ApplicationUsers.Where(m => m.Id == proposal.UserId).FirstOrDefaultAsync(),
                ProposalDetailsList = await db.ProposalDetails.Where(m => m.ProposalId == proposal.Id).ToListAsync()
            };

            return View(UserProDetailVM);
        }

        /// Modifier une proposition


        public async Task<IActionResult> Plus(int productId, int id,UserProposalDetailsViewModel model, int cartId)
        {
            if (id > 0){ 
                 var proposaldetail = await db.ProposalDetails.Where(m => m.ProduitId == id
                                    && m.ProposalId == model.Proposal.Id).FirstOrDefaultAsync();

                proposaldetail.Count++;
                await db.SaveChangesAsync();
                return RedirectToAction("Edit", new { proposalId = proposaldetail.ProposalId });    

            }else{
                var shoppingCart = await db.ShooppingCarts.Where(m => m.ProduitId == productId
                                        && m.Id == cartId).FirstOrDefaultAsync();
                if (shoppingCart != null)
                {
                    shoppingCart.Count++;
                    shoppingCart.Montant = Math.Round(((shoppingCart.Count * shoppingCart.Price) 
                           + ((shoppingCart.Count * shoppingCart.Price) * shoppingCart.Tax) / 100), 2);

                }

                await db.SaveChangesAsync();
                return RedirectToAction("ShoopingCart");
            }
        }

        public async Task<IActionResult> Minus(int productId, int id, UserProposalDetailsViewModel model, int cartId)
        {
            if (id > 0)
            {
                var proposaldetail = await db.ProposalDetails.Where(m => m.ProduitId == id
                                        && m.ProposalId == model.Proposal.Id).FirstOrDefaultAsync();
                if (proposaldetail != null)
                {
                    if (proposaldetail.Count > 1)
                    {
                        proposaldetail.Count--;
                    }
                }
                await db.SaveChangesAsync();
                return RedirectToAction("Edit", new { proposalId = proposaldetail.ProposalId });
            }

            else
            {
                var shoppingCart = await db.ShooppingCarts.Where(m => m.ProduitId == productId
                                        && m.Id == cartId).FirstOrDefaultAsync();
                if (shoppingCart != null)
                {
                    if (shoppingCart.Count > 1)
                    {
                        shoppingCart.Count--;
                        shoppingCart.Montant = Math.Round(((shoppingCart.Count * shoppingCart.Price)
                            + ((shoppingCart.Count * shoppingCart.Price) * shoppingCart.Tax) / 100),2);
                    }
                }

                await db.SaveChangesAsync();
                return RedirectToAction("ShoopingCart");
            }

        }

        public async Task<IActionResult> Remove(int productId, int id, UserProposalDetailsViewModel model, int cartId)
        {
            if(id >0)
            {
                var proposaldetail = await db.ProposalDetails.Where(m => m.ProduitId == id
                                    && m.ProposalId == model.Proposal.Id).FirstOrDefaultAsync();

                if (proposaldetail != null)
                {
                    db.ProposalDetails.Remove(proposaldetail);
                    await db.SaveChangesAsync();
                }

                return RedirectToAction("Edit", new { proposalId = proposaldetail.ProposalId });
            }
            else
            {
                var shoppingCart = await db.ShooppingCarts.Where(m => m.ProduitId == productId
                                    && m.Id == cartId).FirstOrDefaultAsync();

                if (shoppingCart != null)
                {
                    db.ShooppingCarts.Remove(shoppingCart);
                    await db.SaveChangesAsync();
                }

                return RedirectToAction("ShoopingCart");
            }
        }


        // Supprimer un proposition
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteProposal(int proposalId)
        {
            Proposal model = db.Proposals.Find(proposalId);
            if (model == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Erreur lors de la suppression !",
                    html = Helper.RenderRazorViewToString(this, "_ViewAll", await db.Proposals.Include(m => m.ApplicationUser).ToListAsync())
                });
            }
            db.Proposals.Remove(model);
            await db.SaveChangesAsync();
            return Json(new
            {
                success = true,
                message = "Proposition supprimé !",
                html = Helper.RenderRazorViewToString(this, "_ViewAll", await db.Proposals.Include(m => m.ApplicationUser).ToListAsync())
            });
        }

        // Convertir en facture
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConvertToBill(int? proposalId)
        {
            if (proposalId == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Erreur lors de la suppression !",
                    html = Helper.RenderRazorViewToString(this, "_ViewAll", await db.Proposals.Include(m => m.ApplicationUser).ToListAsync())
                });
            }
            var proposal = await db.Proposals.FindAsync(proposalId);
            Bill bill = new Bill()
            {
                UserId = proposal.UserId,
                IssueDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(30),
                Status = SD.StatusNotPaid,
                PhoneNumber = proposal.PhoneNumber,
                BillType = proposal.PoposalType,
                BillTotal = proposal.ProposalTotal,
                BillTotalOrginal = proposal.ProposalTotalOrginal,
                NumBill = ("#Fact/" + DateTime.Now.ToFileTime().ToString()).Substring(1, 18),
                Remise = proposal.Remise,
            };
            proposal.Status = SD.StatusCompleted;
            db.Proposals.Update(proposal);
            await db.Bills.AddAsync(bill);
            await db.SaveChangesAsync();
            var productDetails = await db.ProposalDetails.Where(m => m.ProposalId == proposalId).ToListAsync();


            foreach (var item in productDetails)
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
            await db.SaveChangesAsync();

            return Json(new
            {
                success = true,
                message = "Proposition converti !",
                html = Helper.RenderRazorViewToString(this, "_ViewAll", await db.Proposals.Include(m => m.ApplicationUser).ToListAsync())
            });
        }


        // Send Email
        public async Task<IActionResult> SendProposal(int? id)
        {
            var proposal = await db.Proposals.FindAsync(id);
            var userId = await db.Proposals.Where(m => m.Id == id)
                                 .Select(m => m.UserId).SingleOrDefaultAsync();

            var user = await db.ApplicationUsers.Where(m => m.Id == userId).FirstOrDefaultAsync();

            await _emailSender.SendEmailAsync(user.Email, "Confirmer votre proposition",
                                "Bonjour : " + user.FirstName + " " + user.LastName + "<br/>" +
                                "Vous avez une nouvelle proposition de la part de AppliTaxi <br/>" +
                                "Cliquer sur le lien si dessous pour voir ta proposition <br/>" +
                                "https://localhost:44301/Customer/Proposals/Overview/" + id + "<br/>" + "<hr>" +
                                "<div class='col-md-12'><div class='row ml-1'>" +
                                "<span><img class='pb-2' " +
                                "src='https://is1-ssl.mzstatic.com/image/thumb/Purple118/v4/1b/29/f2/1b29f20e-3004-5715-d070-5356ad545b21/source/512x512bb.jpg' " +
                                "style='width:200px; height:150px;'/></span>" +
                                "<p>28 avenue de la résistance <br />91700 Sainte - Genevièves - des - bois <br />" +
                                "<b> SIRET :</ b > 83138505900017 <br/>France</p>" +
                                "</div></div>");

            proposal.Status = SD.StatusSend;
            db.Proposals.Update(proposal);
            await db.SaveChangesAsync();

            return RedirectToAction("Details", new { proposalId = id });
        }


        //Overview

        public async Task<IActionResult> Overview(int id)
        {
            var proposal = await db.Proposals.FindAsync(id);
            UserProposalDetailsViewModel UserProDetailVM = new UserProposalDetailsViewModel()
            {
                Proposal = proposal,
                ApplicationUser = await db.ApplicationUsers.Where(m => m.Id == proposal.UserId).FirstOrDefaultAsync(),
                ProposalDetailsList = await db.ProposalDetails.Where(m => m.ProposalId == proposal.Id).ToListAsync()
            };

            return View(UserProDetailVM);
        }


        public async Task<IActionResult> Confirm(int id)
        {
            var proposal = await db.Proposals.FindAsync(id);
            proposal.Status = SD.StatusAccepted;
            db.Proposals.Update(proposal);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Reject(int id)
        {
            var proposal = await db.Proposals.FindAsync(id);
            proposal.Status = SD.StatusDeclined;
            db.Proposals.Update(proposal);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        
        [Authorize(Roles = SD.ManagerUser)]
        // HttpGet
        public async Task<IActionResult> ShoopingCart()
        {

            List<string> Users = new List<string>();
            Users = db.ShooppingCarts.Where(m => m.NumProposal != null).Select(m => m.ApplicationUserId).ToList();

            IQueryable<ApplicationUser> ListUsers = from u in db.ApplicationUsers
                                                    where (Users.Contains(u.Id))
                                                    select u;
            IList<ShoppingCartViewModel> ListShoppingCartVM = new List<ShoppingCartViewModel>();


            foreach (var user in ListUsers)
            {
                ShoppingCartViewModel ShoppingCartVM = new ShoppingCartViewModel()
                {
                    ListProposalShooppingCarts = await db.ShooppingCarts.Where(m => m.ApplicationUserId == user.Id 
                                                && m.NumProposal != null).ToListAsync(),
                    ListBilllShooppingCarts = await db.ShooppingCarts.Where(m => m.ApplicationUserId == user.Id 
                                               && m.NumBill != null).ToListAsync(),
                    User = await db.ApplicationUsers.FindAsync(user.Id)
                };

                ShoppingCartVM.ListProducts = await db.Produits.ToListAsync();
                ListShoppingCartVM.Add(ShoppingCartVM);
            }

            return View(ListShoppingCartVM);
        }

        /// <returns></returns>

        public string GetUserId()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            return claim.Value;
        }


    }
}
