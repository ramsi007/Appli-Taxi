using Appli_Taxi.Data;
using Appli_Taxi.Models.ViewModels;
using Appli_Taxi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Appli_Taxi.Utility;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace Appli_Taxi.Areas.Customer.Controllers
{
    [Authorize]
    [Area("Customer")]
    public class ProposalsController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly IEmailSender _emailSender;

        public ProposalsController(ApplicationDbContext _db, IEmailSender emailSender)
        {
            this.db = _db;
            _emailSender = emailSender;
        }

        ProposalDetailsViewModel ProposalDetailsVM = new ProposalDetailsViewModel();

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

        public async Task<IActionResult> Create(string id)
        {
            var proposal = new Proposal();
            proposal.ProposalDate = Convert.ToDateTime(DateTime.Now.ToString("dd-MMMM-yyyy"));

            ProposalDetailsVM.ShooppingCart = new ShooppingCart();
            ProposalDetailsVM.ApplicationUser = new ApplicationUser();

            if (id == null)
            {
                ProposalDetailsVM.UsersList = await db.ApplicationUsers.Where(m => !m.UserRole.Equals(SD.EmployeeUser)).ToListAsync();
                proposal.NumProposal = null;
            }
            else
            {

                ProposalDetailsVM.ShooppingCart.ApplicationUserId = await db.ApplicationUsers.Where(m => m.Id == id).Select(m => m.Id)
                                                                    .FirstOrDefaultAsync();
                ProposalDetailsVM.ApplicationUser = await db.ApplicationUsers.Where(m => m.Id == id).FirstOrDefaultAsync();
                proposal.NumProposal = ("#Prop" + DateTime.Now.ToFileTime().ToString()).Substring(1, 18);

            }

            ProposalDetailsVM.ListShoppingCarts = await db.ShooppingCarts.Where(m => m.ApplicationUserId == id
                                                     && m.NumProposal != null).ToListAsync();

            foreach (var cart in ProposalDetailsVM.ListShoppingCarts)
            {
                proposal.ProposalTotalOrginal += (cart.Price + (cart.Price * cart.Tax / 100)) * cart.Count;

                proposal.Remise += cart.Remise;
            }
            proposal.ProposalTotal = proposal.ProposalTotalOrginal - proposal.Remise;
            ProposalDetailsVM.Proposal = proposal;

            return View(ProposalDetailsVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProposalDetailsViewModel model)
        {
            Proposal proposal = new Proposal()
            {
                UserId = model.ApplicationUser.Id,
                ProposalDate = model.Proposal.ProposalDate,
                Status = SD.StatusInProcess,
                PhoneNumber = model.ApplicationUser.PhoneNumber,
                PoposalType = model.Proposal.PoposalType,
                ProposalTotal = model.Proposal.ProposalTotal,
                ProposalTotalOrginal = model.Proposal.ProposalTotalOrginal,
                NumProposal = model.Proposal.NumProposal,
                Remise = model.Proposal.Remise,
            };

            await db.Proposals.AddAsync(proposal);
            await db.SaveChangesAsync();
            var shoopingcartList = await db.ShooppingCarts.Where(m => m.ApplicationUserId
                        == model.ApplicationUser.Id && m.NumProposal != null).ToListAsync();

            foreach (var item in shoopingcartList)
            {

                ProposalDetail proposalDetail = new ProposalDetail()
                {
                    ProposalId = proposal.Id,
                    ProduitId = item.ProduitId,
                    Remise = item.Remise,
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


        [HttpGet]
        public IActionResult AddToCart(string id)
        {
            List<int> ListproductInShoppingCart = db.ShooppingCarts
                                          .Where(m => m.ApplicationUserId == id && m.NumProposal != null)
                                          .Select(m => m.ProduitId).ToList();

            IQueryable<Produit> Products = from s in db.Produits
                                           where !(ListproductInShoppingCart.Contains(s.Id))
                                           select s;

            ProposalDetailsVM.ProductsList = Products.ToList();
            ProposalDetailsVM.ShooppingCart = new ShooppingCart();
            ProposalDetailsVM.ShooppingCart.ApplicationUserId = id;

            ProposalDetailsVM.Proposal = new Proposal()
            {
                NumProposal = ("#Prop" + DateTime.Now.ToFileTime().ToString()).Substring(1, 18)
            };

            return View(ProposalDetailsVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToCart(ProposalDetailsViewModel model)
        {
            ProposalDetailsVM.ShooppingCart = new ShooppingCart()
            {
                ApplicationUserId = model.ShooppingCart.ApplicationUserId,
                ProduitId = model.ProposalDetail.ProduitId,
                Description = model.ShooppingCart.Description,
                NumProposal = model.Proposal.NumProposal,
                NumBill = null,
                Count = model.ShooppingCart.Count,
                Price = model.ShooppingCart.Price,
                Tax = model.ShooppingCart.Tax,
                Remise = model.ShooppingCart.Remise,
                Montant = model.ShooppingCart.Montant
            };
            await db.ShooppingCarts.AddAsync(ProposalDetailsVM.ShooppingCart);
            await db.SaveChangesAsync();
            return RedirectToAction("Create", new { id = model.ShooppingCart.ApplicationUserId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveCart(int productId)
        {
            var shoopingCart = await db.ShooppingCarts.Where(m => m.ProduitId == productId).FirstOrDefaultAsync();

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

        [HttpGet]
        public async Task<IActionResult> getUserById(string id)
        {
            var user = await db.ApplicationUsers.Where(m => m.Id == id).FirstOrDefaultAsync();
            return new JsonResult(user);
        }

        //////////
        /// Detail et paerçu de la proposition
        ////

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


        //////////
        /// Edit proposition
        ////
        ///
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

        //////////
        /// Edit proposition
        ////
        ///

        public async Task<IActionResult> Plus(int id, UserProposalDetailsViewModel model)
        {
            var proposaldetail = await db.ProposalDetails.Where(m => m.ProduitId == id
                                && m.ProposalId == model.Proposal.Id).FirstOrDefaultAsync();

            proposaldetail.Count++;
            await db.SaveChangesAsync();
            return RedirectToAction("Edit", new { proposalId = proposaldetail.ProposalId });
        }

        public async Task<IActionResult> Minus(int id, UserProposalDetailsViewModel model)
        {
            var proposaldetail = await db.ProposalDetails.Where(m => m.ProduitId == id
                                    && m.ProposalId == model.Proposal.Id).FirstOrDefaultAsync();
            if (proposaldetail != null)
            {
                if (proposaldetail.Count > 1)
                {
                    proposaldetail.Count--;
                    await db.SaveChangesAsync();
                }
            }

            return RedirectToAction("Edit", new { proposalId = proposaldetail.ProposalId });
        }

        public async Task<IActionResult> Remove(int id, UserProposalDetailsViewModel model)
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

        [HttpGet]
        public IActionResult AddProducts(int id)
        {
            ProposalDetail proposalDetail = new ProposalDetail()
            {
                ProposalId = id,
                Count = 1,
                Remise = 0
            };
            List<int> ListproductInShoppingCart = db.ProposalDetails
                                          .Where(m => m.ProposalId == id)
                                          .Select(m => m.ProduitId).ToList();

            IQueryable<Produit> Products = from s in db.Produits
                                           where !(ListproductInShoppingCart.Contains(s.Id))
                                           select s;
            ProposalDetailsVM.ProductsList = Products.ToList();
            ProposalDetailsVM.ProposalDetail = proposalDetail;

            return View(ProposalDetailsVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProducts(ProposalDetailsViewModel model)
        {
            string nameProduct = await db.Produits.Where(m => m.Id == model.ProposalDetail.ProduitId)
                                .Select(m => m.Name).FirstOrDefaultAsync();

            ProposalDetailsVM.ProposalDetail = new ProposalDetail()
            {
                ProposalId = model.ProposalDetail.ProposalId,
                ProduitId = model.ProposalDetail.ProduitId,
                Remise = model.ProposalDetail.Remise,
                Count = model.ProposalDetail.Count,
                Name = nameProduct,
                Description = model.ProposalDetail.Description,
                Price = model.ProposalDetail.Price,
                Tax = model.ProposalDetail.Tax
            };

            await db.ProposalDetails.AddAsync(ProposalDetailsVM.ProposalDetail);
            await db.SaveChangesAsync();
            return RedirectToAction("Edit", new { proposalId = model.ProposalDetail.ProposalId });
        }

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


        // Convert To Bill
        //public async Task<IActionResult> ConvertToBill(int proposalId)
        //{
        //    var proposal = await db.Proposals.FindAsync(proposalId);
        //    return View(proposal);
        //}

        /// <returns></returns>

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
                Status = SD.StatusInProcess,
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
                                "https://localhost:44300/Customer/Proposals/Overview/" + id + "<br/>" + "<hr>" +
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
        /// <summary>
        /// 

        public string GetUserId()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            return claim.Value;
        }
    }
}
