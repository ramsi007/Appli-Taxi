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

namespace Appli_taxi.Areas.Customer.Controllers
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
            var ListNotes = new List<CreeditNote>();
            if (User.IsInRole(SD.ManagerUser))
            {
                ListNotes = await db.CreeditNotes.Include(m => m.ApplicationUser).Include(m => m.Bill).ToListAsync();
            }
            else
            {
                ListNotes = await db.CreeditNotes.Include(m => m.ApplicationUser).Include(m => m.Bill)
                         .Where(m => m.UserId == GetUserId()).ToListAsync();
            }
            return View(ListNotes);
        }

        public async Task<IActionResult> Create(int billId)
        {
            IList<Bill> bills = new List<Bill>();
            CreeditNote credit = new CreeditNote();
            Bill bill = new Bill();

            if (billId == 0)
            {
                bills = await db.Bills.ToListAsync();
                if(bills.Count == 1)
                {
                    bill = bills[0];
                }
            }
            else
            {
                bills = await db.Bills.Where(m => m.Id == billId).ToListAsync();
                bill = await db.Bills.Where(m => m.Id == billId).FirstOrDefaultAsync();
                credit.BillId = billId;
            }

            CreditNoteBillsViewModel creditNoteBillsVM = new CreditNoteBillsViewModel()
            {
                ListBills = bills,
                Bill = bill,
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
                var bill = await db.Bills.Where(m => m.Id == model.CreditNote.BillId).FirstOrDefaultAsync();

                CreeditNote creditnote = new CreeditNote()
                {
                    UserId = await db.Bills.Where(m => m.Id == bill.Id).Select(m => m.UserId)
                                .FirstOrDefaultAsync(),
                    BillId = bill.Id
                };
                model.CreditNote.BillId = creditnote.BillId;
                model.CreditNote.UserId = creditnote.UserId;

                await db.CreeditNotes.AddAsync(model.CreditNote);
                await db.SaveChangesAsync();

                UpdateBill(bill.Id);

                return Json(new
                {
                    success = true,
                    message = "Note de crédit ajouté !",
                    isValid = true,
                    html = Helper.RenderRazorViewToString(this, "_ViewAll",
                    await db.CreeditNotes.Include(m => m.ApplicationUser).Include(m => m.Bill).ToListAsync())
                });
            }

            CreditNoteBillsViewModel creditNoteBillsVM = new CreditNoteBillsViewModel()
            {
                ListBills = await db.Bills.ToListAsync(),
                CreditNote = new CreeditNote()
            };
            creditNoteBillsVM.CreditNote.NoteDate = Convert.ToDateTime(DateTime.Now.ToString("dd-MMMM-yyyy"));

            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Create", creditNoteBillsVM) });
        }


        public async Task<IActionResult> Edit(int id)
        {
            CreditNoteBillsViewModel creditNoteBillsVM = new CreditNoteBillsViewModel()
            {
                ListBills = await db.Bills.ToListAsync(),
                CreditNote = await db.CreeditNotes.FindAsync(id)
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
                Bill bill = await db.Bills.Where(m => m.Id == model.CreditNote.BillId).FirstOrDefaultAsync();

                db.CreeditNotes.Update(model.CreditNote);
                await db.SaveChangesAsync();

                UpdateBill(bill.Id);

                return Json(new
                {
                    success = true,
                    message = "Node de crédit modifié !",
                    isValid = true,
                    html = Helper.RenderRazorViewToString(this, "_ViewAll", await db.CreeditNotes.Include(m => m.ApplicationUser).Include(m => m.Bill).ToListAsync())
                });
            }

            CreditNoteBillsViewModel creditNoteBillsVM = new CreditNoteBillsViewModel()
            {
                ListBills = await db.Bills.ToListAsync(),
                CreditNote = new CreeditNote()
            };
            creditNoteBillsVM.CreditNote.NoteDate = Convert.ToDateTime(DateTime.Now.ToString("dd-MMMM-yyyy"));

            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Edit", creditNoteBillsVM) });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            CreeditNote model = db.CreeditNotes.Find(id);
            if (model == null)
            {
                return Json(new { success = false, message = "Erreur lors de la suppression !", html = Helper.RenderRazorViewToString(this, "_ViewAll", await db.CreeditNotes.Include(m => m.ApplicationUser).Include(m => m.Bill).ToListAsync()) });
            }
            db.CreeditNotes.Remove(model);
            await db.SaveChangesAsync();

            UpdateBill(model.BillId);

            return Json(new { success = true, message = "Note de crédit supprimé !", html = Helper.RenderRazorViewToString(this, "_ViewAll", await db.CreeditNotes.Include(m => m.ApplicationUser).Include(m => m.Bill).ToListAsync()) });
        }


        // Get User By Id
        public string GetUserId()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            return claim.Value;
        }

        public void UpdateBill(int? id)
        {
            var bill = db.Bills.Find(id);
            bill.BillTotalOrginal = 0; bill.Remise = 0;
            var ListProductInBillDetails = db.BillDetails.Where(m => m.BillId == id).ToList();


            double totalAmountPaid = 0, totalNoteAmount = 0;
            List<double> listAmountPaid = db.Receipts.Include(m => m.Bill).Where(m => m.BillId == id)
                                    .Select(m => m.Montant).ToList();

            List<double> listCreditNotes = db.CreeditNotes.Include(m => m.Bill).Where(m => m.BillId == id)
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
                bill.BillTotalOrginal += Math.Round((product.Count * product.Price) + ((product.Count * product.Price) * product.Tax) / 100, 2);
                bill.Remise += Convert.ToDouble(product.Remise);
            }
            bill.BillTotal = Math.Round((bill.BillTotalOrginal - bill.Remise), 2);
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
