using Appli_Taxi.Data;
using Appli_Taxi.Models;
using Appli_Taxi.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appli_taxi.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TaxesController : Controller
    {
        private readonly ApplicationDbContext db;

        public TaxesController(ApplicationDbContext _db)
        {
            this.db = _db;
        }

        public async Task<IActionResult> Index()
        {
            var Taxes = await db.Taxes.ToListAsync();
            return View(Taxes);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Tax model)
        {
            if (ModelState.IsValid)
            {
                var ExistingTax = await db.Taxes.Where(m => m.Name.ToLower() == model.Name.ToLower()
                                    && m.Discount == model.Discount).ToListAsync();

                if (ExistingTax.Count == 0)
                {
                    await db.Taxes.AddAsync(model);
                    await db.SaveChangesAsync();

                    return Json(new { success = true, message = "Tax ajouté !", isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await db.Taxes.ToListAsync()) });
                }
                else
                {
                    return Json(new { success = false, message = "Erreur : cette tax exite déja !", isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await db.Taxes.ToListAsync()) });
                }

            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Create", model) });

        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tax = await db.Taxes.FindAsync(id);

            if (tax == null)
            {
                return NotFound();
            }
            return View(tax);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Tax model)
        {
            if (ModelState.IsValid)
            {
                var ExistingTax = await db.Taxes.Where(m => m.Name.ToLower() == model.Name.ToLower()
                    && m.Discount == model.Discount).ToListAsync();
                if (ExistingTax.Count == 0)
                {
                    db.Taxes.Update(model);
                    await db.SaveChangesAsync();
                    return Json(new { success = true, message = "Tax modifié !", isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await db.Taxes.ToListAsync()) });
                }
                else
                {
                    return Json(new { success = false, message = "Erreur : cette tax exite déja !", isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await db.Taxes.ToListAsync()) });
                }
            }
            return View(model);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var produitList = await db.Produits.Include(m => m.Tax)
        //                      .Where(m => m.TaxId == id).ToListAsync();

        //    if (produitList.Count() > 0)
        //    {
        //        return Json(new
        //        {
        //            success = false,
        //            message = "Ouups ...! vous pouvez pas supprimer cette taxe " +
        //            "car elle est lié à un ou plusieurs produits",
        //            isValid = false,
        //            html = Helper.RenderRazorViewToString(this, "_ViewAll", await db.Taxes.ToListAsync())
        //        });
        //    }

        //    var tax = db.Taxes.Find(id);

        //    db.Taxes.Remove(tax);
        //    await db.SaveChangesAsync();
        //    return Json(new { success = true, message = "taxe supprimé !", isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await db.Taxes.ToListAsync()) });
        //}


        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tax = await db.Taxes.FindAsync(id);
            if (tax == null)
            {
                return NotFound();
            }
            return PartialView("DetailsPartial/_TaxeDetails", tax);
        }

    }
}
