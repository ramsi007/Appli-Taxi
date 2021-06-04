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
using System.Threading.Tasks;

namespace Appli_Taxi.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Customer")]
    public class ReceiptsController : Controller
    {
        private readonly ApplicationDbContext db;

        public ReceiptsController(ApplicationDbContext _db)
        {
            this.db = _db;
        }

        public async Task<IActionResult> Index()
        {
            var RecieptList = new List<Receipt>();

            RecieptList = await db.Receipts.Include(m => m.ApplicationUser).Include(m => m.Bill)
                         .ToListAsync();

            return View(RecieptList);
        }

        public async Task<IActionResult> Create(int id)
        {
            IList<Bill> bills = new List<Bill>();
            string numbill = null;
            Receipt receipt = new Receipt();
            if (id == 0)
            {
                bills = await db.Bills.ToListAsync();
            }
            else
            {
                bills = await db.Bills.Where(m => m.Id == id).ToListAsync();
                numbill = await db.Bills.Where(m => m.Id == id).Select(m => m.NumBill).FirstOrDefaultAsync();
                receipt.BillId = id;
                receipt.Montant = await db.Bills.Where(m => m.Id == id).Select(m => m.Rest).FirstOrDefaultAsync();
            }

            CreditNoteBillsViewModel creditNoteReceiptBillsVM = new CreditNoteBillsViewModel()
            {
                ListBills = bills,
                NumBill = numbill,
                Receipt = receipt,
            };
            creditNoteReceiptBillsVM.Receipt.RecieptDate = Convert.ToDateTime(DateTime.Now.ToString("dd-MMMM-yyyy"));

            return View(creditNoteReceiptBillsVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreditNoteBillsViewModel model)
        {
            if (ModelState.IsValid)
            {
                Receipt receipt = new Receipt()
                {
                    UserId = await db.Bills.Where(m => m.Id == model.Receipt.BillId).Select(m => m.UserId)
                                .FirstOrDefaultAsync()
                };
                model.Receipt.UserId = receipt.UserId;

                await db.Receipts.AddAsync(model.Receipt);
                await db.SaveChangesAsync();
                // Find and Update bill

                var bill = await db.Bills.Where(m => m.Id == model.Receipt.BillId).FirstOrDefaultAsync();
                receipt = await db.Receipts.FindAsync(model.Receipt.Id);
                bill.Paid += receipt.Montant;
                bill.Rest -= receipt.Montant;

                db.Bills.Update(bill);
                await db.SaveChangesAsync();

                db.Bills.Update(bill);
                await db.SaveChangesAsync();

                return Json(new
                {
                    success = true,
                    message = "nouvelle réception ajouté !",
                    isValid = true,
                    html = Helper.RenderRazorViewToString(this, "_ViewAll",
                    await db.Receipts.Include(m => m.ApplicationUser).Include(m => m.Bill).ToListAsync())
                });
            }

            CreditNoteBillsViewModel creditNoteReceiptBillsVM = new CreditNoteBillsViewModel()
            {
                ListBills = await db.Bills.ToListAsync(),
                Receipt = new Receipt()
            };
            creditNoteReceiptBillsVM.Receipt.RecieptDate = Convert.ToDateTime(DateTime.Now.ToString("dd-MMMM-yyyy"));

            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Create", creditNoteReceiptBillsVM) });
        }
    }
}
