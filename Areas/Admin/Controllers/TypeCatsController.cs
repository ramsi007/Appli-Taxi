using Appli_Taxi.Data;
using Appli_Taxi.Models;
using Appli_Taxi.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appli_Taxi.Areas.Admin.Controllers
{
    //[Authorize(Roles = SD.ManagerUser)]
    [Area("Admin")]
    public class TypeCatsController : Controller
    {
        private readonly ApplicationDbContext db;

        public TypeCatsController(ApplicationDbContext _db)
        {
            this.db = _db;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var TypeList = await db.TypeCats.ToListAsync();
            return View(TypeList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TypeCat typeCat)
        {
            if (ModelState.IsValid)
            {
                var ExistingType = await db.TypeCats.Where(m => m.Name.ToLower() == typeCat.Name.ToLower())
                                        .ToListAsync();

                if (ExistingType.Count == 0)
                {
                    await db.TypeCats.AddAsync(typeCat);
                    await db.SaveChangesAsync();

                    return Json(new { success = true, message = "Type ajouté !", isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await db.Taxes.ToListAsync()) });
                }
                else
                {
                    return Json(new { success = false, message = "Erreur : ce type exite déja !", isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await db.TypeCats.ToListAsync()) });
                }

            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Create", typeCat) });

        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeCat = await db.TypeCats.FindAsync(id);
            if (typeCat == null)
            {
                return NotFound();
            }
            return PartialView("DetailsPartial/_TypeDetails", typeCat);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeCat = await db.TypeCats.FindAsync(id);
            if (typeCat == null)
            {
                return NotFound();
            }
            return View(typeCat);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TypeCat typeCat)
        {
            if (ModelState.IsValid)
            {
                var ExistingType = await db.TypeCats.Where(m => m.Name.ToLower() == typeCat.Name.ToLower())
                                        .ToListAsync();

                if (ExistingType.Count == 0)
                {
                    db.TypeCats.Update(typeCat);
                    await db.SaveChangesAsync();

                    return Json(new { success = true, message = "Type modifié !", isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await db.Taxes.ToListAsync()) });
                }
                else
                {
                    return Json(new { success = false, message = "Erreur : ce type exite déja !", isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await db.TypeCats.ToListAsync()) });
                }

            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Create", typeCat) });

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteType(int id)
        {
            var CategoriesList = await db.Categories.Include(m => m.TypeCat)
                                       .Where(m => m.TypeId == id).ToListAsync();

            if (CategoriesList.Count() > 0)
            {
                return Json(new
                {
                    success = false,
                    message = "Ouups ...! vous pouvez pas supprimer ce type " +
                    "car elle est lié à un ou plusieurs catégories",
                    isValid = false,
                    html = Helper.RenderRazorViewToString(this, "_ViewAll", await db.TypeCats.ToListAsync())
                });
            }

            var type = db.TypeCats.Find(id);

            db.TypeCats.Remove(type);
            await db.SaveChangesAsync();
            return Json(new { success = true, message = "type supprimé !", isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await db.TypeCats.ToListAsync()) });
        }

    }
}

