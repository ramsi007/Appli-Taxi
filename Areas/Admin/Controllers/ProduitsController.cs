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
    public class ProduitsController : Controller
    {
        private readonly ApplicationDbContext db;

        public ProduitsController(ApplicationDbContext _db)
        {
            this.db = _db;
        }

        public async Task<IActionResult> Index()
        {
            var produits = await db.Produits.Include(m => m.Category).Include(m => m.Tax).ToListAsync();
            return View(produits);
        }


        //HttpGet
        public async Task<IActionResult> Create()
        {
            ProduitViewModel ProductVM = new ProduitViewModel()
            {
                Produit = new Produit(),
                CategoriesList = await db.Categories.ToListAsync(),
                TaxesList = await db.Taxes.ToListAsync()
            };
            return View(ProductVM);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProduitViewModel model)
        {
            if (ModelState.IsValid)
            {
                var ExistingProduct = await db.Produits.Where(m => m.Name.ToLower().Equals(model.Produit.Name.ToLower()))
                .ToListAsync();

                if (ExistingProduct.Count == 0)
                {
                    await db.Produits.AddAsync(model.Produit);
                    await db.SaveChangesAsync();
                    return Json(new
                    {
                        success = true,
                        message = "Produit ajouté !",
                        isValid = true,
                        html = Helper.RenderRazorViewToString(this, "_ViewAll",
                        await db.Produits.Include(m => m.Category).Include(m => m.Tax).ToListAsync())
                    });
                }
                else
                {
                    return Json(new
                    {
                        success = false,
                        message = "Erreur : ce nom de produit existe déja !",
                        isValid = true,
                        html = Helper.RenderRazorViewToString(this, "_ViewAll", await db.Produits.Include(m => m.Tax).Include(m => m.Category).ToListAsync())
                    });
                }
            }

            ProduitViewModel ProductVM = new ProduitViewModel()
            {
                Produit = new Produit(),
                CategoriesList = await db.Categories.ToListAsync(),
                TaxesList = await db.Taxes.ToListAsync()
            };
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Create", ProductVM) });

        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = await db.Produits.Include(m => m.Category).Include(m => m.Tax)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            ProduitViewModel ProductVM = new ProduitViewModel()
            {
                Produit = product,
                CategoriesList = await db.Categories.Where(m => m.Id == product.CategoryId).ToListAsync(),
                TaxesList = await db.Taxes.Where(m => m.Id == product.TaxId).ToListAsync()
            };

            return View(ProductVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProduitViewModel model)
        {
            if (ModelState.IsValid)
            {
                var ExistingProduct = await db.Produits.Where(m => m.Name.ToLower().Equals(model.Produit.Name.ToLower()))
                        .ToListAsync();

                if (ExistingProduct.Count == 0)
                {
                    db.Produits.Update(model.Produit);
                    await db.SaveChangesAsync();
                    return Json(new { success = true, message = "Produit modifié !", isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", await db.Produits.Include(m => m.Category).Include(m => m.Tax).ToListAsync()) });
                }
                else
                {
                    return Json(new { 
                        success = false, 
                        message = "Erreur : ce nom de produit existe déja !", 
                        isValid = true, 
                        html = Helper.RenderRazorViewToString(this, "_ViewAll", await db.Produits.Include(m=>m.Tax).Include(m=>m.Category).ToListAsync()) });
                }
            }

            ProduitViewModel ProductVM = new ProduitViewModel()
            {
                Produit = model.Produit,
                CategoriesList = await db.Categories.Where(m => m.Id == model.Produit.CategoryId).ToListAsync(),
                TaxesList = await db.Taxes.Where(m => m.Id == model.Produit.TaxId).ToListAsync()
            };
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Edit", ProductVM) });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            Produit model = await db.Produits.FindAsync(id);
            var listProductsInCart = await db.ShooppingCarts.Where(m => m.ProduitId == id)
                                        .ToListAsync();
            if (model == null)
            {
                return Json(new { success = false, message = "Erreur lors de la suppression !", html = Helper.RenderRazorViewToString(this, "_ViewAll", await db.Produits.ToListAsync()) });
            }
            db.Produits.Remove(model);
            if(listProductsInCart.Count>0)
            {
                db.ShooppingCarts.RemoveRange(listProductsInCart);
            }
            await db.SaveChangesAsync();
            return Json(new { success = true, message = "Produit supprimé !", html = Helper.RenderRazorViewToString(this, "_ViewAll", await db.Produits.ToListAsync()) });
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produit = await db.Produits.FindAsync(id);
            if (produit == null)
            {
                return NotFound();
            }

            ProduitViewModel produitVM = new ProduitViewModel()
            {
                Produit = produit,
                CategoriesList = await db.Categories.Where(m => m.Id == produit.CategoryId).ToListAsync(),
                TaxesList = await db.Taxes.Where(m => m.Id == produit.TaxId).ToListAsync()
            };

            return PartialView("DetailsPartial/_ProductDetails", produitVM);
        }

    }
}
