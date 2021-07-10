using Appli_taxi.Data;
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

namespace Appli_taxi.Areas.Admin.Controllers
{
    [Authorize(Roles = SD.ManagerUser)]
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext db;

        [TempData]
        public string StatusMessage { get; set; }

        public CategoriesController(ApplicationDbContext _db)
        {
            this.db = _db;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var Categories = await db.Categories.Include(m => m.TypeCat).ToListAsync();
            return View(Categories);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            TypeAndCategoryViewModel TypeAndCatVM = new TypeAndCategoryViewModel()
            {
                Category = new Category(),
                ListTypes = await db.TypeCats.ToListAsync()
            };

            return View(TypeAndCatVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TypeAndCategoryViewModel model)
        {

            TypeAndCategoryViewModel modelVM = new TypeAndCategoryViewModel()
            {
                Category = model.Category,
                ListTypes = await db.TypeCats.ToListAsync(),
            };

            if (ModelState.IsValid)
            {
                var isExistCategory = db.Categories.Include(m => m.TypeCat)
                                         .Where(m => m.TypeCat.Id == model.Category.TypeId
                                          && m.Name.ToLower().Equals(model.Category.Name.ToLower())).ToList();

                if (isExistCategory.Count() > 0)
                {
                    return Json(new { success = false, message = "Erreur ...! cette catégorie existe déja", isValid = true, html = Helper.RenderRazorViewToString(this, "Create", modelVM) });
                }
                else
                {
                    await db.Categories.AddAsync(model.Category);
                    await db.SaveChangesAsync();

                    return Json(new { success = true, message = "Catégorie ajouté !", isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await db.Categories.Include(m => m.TypeCat).ToListAsync()) });
                }
            }
            return Json(new { success = false, message = "Erreur ... !", isValid = false, html = Helper.RenderRazorViewToString(this, "Create", modelVM) });
        }

        //    return View(modelVM);

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Category = await db.Categories.FindAsync(id);

            if (Category == null)
            {
                return NotFound();
            }

            TypeAndCategoryViewModel TypeAndCatVM = new TypeAndCategoryViewModel()
            {
                Category = await db.Categories.FindAsync(id),
                ListTypes = await db.TypeCats.ToListAsync()
            };

            return View(TypeAndCatVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TypeAndCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {

                var isExistCategory = db.Categories.Include(m => m.TypeCat)
                                         .Where(m => m.TypeCat.Id == model.Category.TypeId
                                          && m.Name.ToLower().Equals(model.Category.Name.ToLower())).ToList();

                TypeAndCategoryViewModel modelVM = new TypeAndCategoryViewModel()
                {
                    Category = model.Category,
                    ListTypes = await db.TypeCats.ToListAsync(),
                };

                if (isExistCategory.Count() > 0)
                {
                    return Json(new { success = false, message = "Erreur ...! cette catégorie existe déja", isValid = false, html = Helper.RenderRazorViewToString(this, "Edit", modelVM) });
                }
                else
                {
                    db.Categories.Update(model.Category);
                    await db.SaveChangesAsync();

                    return Json(new { success = true, message = "Catégorie modifié !", isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await db.Categories.Include(m => m.TypeCat).ToListAsync()) });
                }
            }
            return Json(new { success = false, message = "Erreur ... !", isValid = false, html = Helper.RenderRazorViewToString(this, "Edit", model) });
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var produitList = await db.Produits.Include(m => m.Category)
        //                   .Where(m => m.CategoryId == id).ToListAsync();

        //    if (produitList.Count() > 0)
        //    {
        //        return Json(new
        //        {
        //            success = false,
        //            message = "Ouups ...! vous pouvez pas supprimer cette catégorie " +
        //            "car elle est lié à un ou plusieurs produits",
        //            isValid = false,
        //            html = Helper.RenderRazorViewToString(this, "_ViewAll", await db.Categories.Include(m => m.TypeCat).ToListAsync())
        //        });
        //    }

        //    var category = db.Categories.Find(id);

        //    db.Categories.Remove(category);
        //    await db.SaveChangesAsync();
        //    return Json(new { success = true, message = "Catégorie supprimé !", isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await db.Categories.Include(m => m.TypeCat).ToListAsync()) });
        //}

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {

            var category = await db.Categories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            TypeAndCategoryViewModel TypeAndCatVM = new TypeAndCategoryViewModel()
            {
                Category = await db.Categories.FindAsync(id),
                ListTypes = await db.TypeCats.ToListAsync()
            };

            return PartialView("DetailsPartial/_CategoryDetails", TypeAndCatVM);
        }
    }
}
