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

namespace Appli_taxi.Areas.Customer.Controllers
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
            Bill bill = new Bill();
            Receipt receipt = new Receipt();
            if (id == 0)
            {
                bills = await db.Bills.ToListAsync();
                if (bills.Count == 1)
                {
                    bill = bills[0];
                }
            }
            else
            {
                bills = await db.Bills.Where(m => m.Id == id).ToListAsync();
                bill = await db.Bills.Where(m => m.Id == id).FirstOrDefaultAsync();
                receipt.BillId = id;
                receipt.Montant = await db.Bills.Where(m => m.Id == id).Select(m => m.Rest).FirstOrDefaultAsync();
            }

            CreditNoteBillsViewModel creditNoteReceiptBillsVM = new CreditNoteBillsViewModel()
            {
                ListBills = bills,
                Bill = bill,
                Receipt = receipt,
            };
            creditNoteReceiptBillsVM.Receipt.RecieptDate = Convert.ToDateTime(DateTime.Now.ToString("dd-MMMM-yyyy"));

            return View(creditNoteReceiptBillsVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreditNoteBillsViewModel model)
        {
            CreditNoteBillsViewModel creditNoteReceiptBillsVM = new CreditNoteBillsViewModel()
            {
                ListBills = await db.Bills.ToListAsync(),
                Receipt = new Receipt()
            };
            creditNoteReceiptBillsVM.Receipt.RecieptDate = Convert.ToDateTime(DateTime.Now.ToString("dd-MMMM-yyyy"));

            if (ModelState.IsValid)
            {
                var bill = await db.Bills.Where(m => m.Id == model.Receipt.BillId).FirstOrDefaultAsync();

                model.Receipt.UserId = bill.UserId;


                if(model.Receipt.Montant>bill.Rest)
                {
                    creditNoteReceiptBillsVM.StatusMessage = "Erreur : Le montant saisi ne doit pas être supérieur à " + bill.Rest;

                    return Json(new { isValid = false,
                    html = Helper.RenderRazorViewToString(this, "Create", creditNoteReceiptBillsVM) });
                }

                await db.Receipts.AddAsync(model.Receipt);
                await db.SaveChangesAsync();

                // Find and Update bill
                UpdateBill(bill.Id);

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

            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Create", creditNoteReceiptBillsVM) });
        }


        public async Task<IActionResult> Edit(int id)
        {
            CreditNoteBillsViewModel creditNoteBillsVM = new CreditNoteBillsViewModel()
            {
                ListBills = await db.Bills.ToListAsync(),
                Receipt = await db.Receipts.FindAsync(id)
            };
            creditNoteBillsVM.Receipt.RecieptDate = Convert.ToDateTime(DateTime.Now.ToString("dd-MMMM-yyyy"));
            return View(creditNoteBillsVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CreditNoteBillsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var bill = await db.Bills.Where(m => m.Id == model.Receipt.BillId).FirstOrDefaultAsync();

                db.Receipts.Update(model.Receipt);
                await db.SaveChangesAsync();

                UpdateBill(bill.Id);

                return Json(new
                {
                    success = true,
                    message = "Note de reçu modifié !",
                    isValid = true,
                    html = Helper.RenderRazorViewToString(this, "_ViewAll", await db.Receipts.Include(m => m.ApplicationUser).Include(m => m.Bill).ToListAsync())
                });
            }

            CreditNoteBillsViewModel creditNoteBillsVM = new CreditNoteBillsViewModel()
            {
                ListBills = await db.Bills.ToListAsync(),
                Receipt = new Receipt()
            };
            creditNoteBillsVM.Receipt.RecieptDate = Convert.ToDateTime(DateTime.Now.ToString("dd-MMMM-yyyy"));

            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Edit", creditNoteBillsVM) });
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
