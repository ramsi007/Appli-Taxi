using Appli_Taxi.Data;
using Appli_Taxi.Models;
using Appli_Taxi.Models.ViewModels;
using Appli_Taxi.Utility;
using Microsoft.AspNetCore.Authorization;
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
    public class CreditNotesController : Controller
    {
        private readonly ApplicationDbContext db;

        public CreditNotesController(ApplicationDbContext _db)
        {
            this.db = _db;
        }

        public async Task<IActionResult> Index()
        {
            var ListNotes = new List<CreditNote>();
            if (User.IsInRole(SD.ManagerUser))
            {
                ListNotes = await db.CreditNotes.Include(m => m.ApplicationUser).Include(m => m.Bill).ToListAsync();
            }
            else
            {
                ListNotes = await db.CreditNotes.Include(m => m.ApplicationUser).Include(m => m.Bill)
                         .Where(m => m.UserId == GetUserId()).ToListAsync();
            }
            return View(ListNotes);
        }

        public async Task<IActionResult> Create(int id)
        {
            IList<Bill> bills = new List<Bill>();
            string numbill = null;
            CreditNote credit = new CreditNote();
            if (id == 0)
            {
                bills = await db.Bills.ToListAsync();
            }
            else
            {
                bills = await db.Bills.Where(m => m.Id == id).ToListAsync();
                numbill = await db.Bills.Where(m => m.Id == id).Select(m => m.NumBill).FirstOrDefaultAsync();
                credit.BillId = id;
            }

            CreditNoteBillsViewModel creditNoteBillsVM = new CreditNoteBillsViewModel()
            {
                ListBills = bills,
                NumBill = numbill,
                CreditNote = credit
            };
            creditNoteBillsVM.CreditNote.NoteDate = Convert.ToDateTime(DateTime.Now.ToString("dd-MMMM-yyyy"));
            return View(creditNoteBillsVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreditNoteBillsViewModel model)
        {
            if (ModelState.IsValid)
            {

                var billDetailsList = await db.BillDetails.Where(m => m.BillId == model.CreditNote.BillId)
                                      .ToListAsync();

                CreditNote creditnote = new CreditNote()
                {
                    UserId = await db.Bills.Where(m => m.Id == model.CreditNote.BillId).Select(m => m.UserId)
                                .FirstOrDefaultAsync()
                };
                model.CreditNote.UserId = creditnote.UserId;

                await db.CreditNotes.AddAsync(model.CreditNote);
                await db.SaveChangesAsync();

                var bill = await db.Bills.Where(m => m.Id == model.CreditNote.BillId).FirstOrDefaultAsync();
                creditnote = await db.CreditNotes.FindAsync(model.CreditNote.Id);
                bill.Rest -= creditnote.Montant;

                db.Bills.Update(bill);
                await db.SaveChangesAsync();

                return Json(new
                {
                    success = true,
                    message = "Note de crédit ajouté !",
                    isValid = true,
                    html = Helper.RenderRazorViewToString(this, "_ViewAll",
                    await db.CreditNotes.Include(m => m.ApplicationUser).Include(m => m.Bill).ToListAsync())
                });
            }

            CreditNoteBillsViewModel creditNoteBillsVM = new CreditNoteBillsViewModel()
            {
                ListBills = await db.Bills.ToListAsync(),
                CreditNote = new CreditNote()
            };
            creditNoteBillsVM.CreditNote.NoteDate = Convert.ToDateTime(DateTime.Now.ToString("dd-MMMM-yyyy"));

            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Create", creditNoteBillsVM) });
        }


        public async Task<IActionResult> Edit(int id)
        {
            CreditNoteBillsViewModel creditNoteBillsVM = new CreditNoteBillsViewModel()
            {
                ListBills = await db.Bills.ToListAsync(),
                CreditNote = await db.CreditNotes.FindAsync(id)
            };
            creditNoteBillsVM.CreditNote.NoteDate = Convert.ToDateTime(DateTime.Now.ToString("dd-MMMM-yyyy"));
            return View(creditNoteBillsVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CreditNoteBillsViewModel model)
        {
            if (ModelState.IsValid)
            {
                db.CreditNotes.Update(model.CreditNote);
                await db.SaveChangesAsync();
                return Json(new
                {
                    success = true,
                    message = "Node de crédit modifié !",
                    isValid = true,
                    html = Helper.RenderRazorViewToString(this, "_ViewAll", await db.CreditNotes.Include(m => m.ApplicationUser).Include(m => m.Bill).ToListAsync())
                });
            }

            CreditNoteBillsViewModel creditNoteBillsVM = new CreditNoteBillsViewModel()
            {
                ListBills = await db.Bills.ToListAsync(),
                CreditNote = new CreditNote()
            };
            creditNoteBillsVM.CreditNote.NoteDate = Convert.ToDateTime(DateTime.Now.ToString("dd-MMMM-yyyy"));

            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Edit", creditNoteBillsVM) });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            CreditNote model = db.CreditNotes.Find(id);
            if (model == null)
            {
                return Json(new { success = false, message = "Erreur lors de la suppression !", html = Helper.RenderRazorViewToString(this, "_ViewAll", await db.CreditNotes.Include(m => m.ApplicationUser).Include(m => m.Bill).ToListAsync()) });
            }
            db.CreditNotes.Remove(db.CreditNotes.Find(id));
            await db.SaveChangesAsync();
            return Json(new { success = true, message = "Note de crédit supprimé !", html = Helper.RenderRazorViewToString(this, "_ViewAll", await db.CreditNotes.Include(m => m.ApplicationUser).Include(m => m.Bill).ToListAsync()) });
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var creditNote = await db.CreditNotes.FindAsync(id);
            if (creditNote == null)
            {
                return NotFound();
            }

            CreditNoteBillsViewModel creditNoteBillsVM = new CreditNoteBillsViewModel()
            {
                CreditNote = creditNote,
                ListBills = await db.Bills.Where(m => m.Id == creditNote.BillId).ToListAsync()

            };

            return View(creditNoteBillsVM);
        }

        // Get User By Id
        public string GetUserId()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            return claim.Value;
        }
    }
}
