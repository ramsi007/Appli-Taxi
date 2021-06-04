using Appli_Taxi.Data;
using Appli_Taxi.Models;
using Appli_Taxi.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appli_Taxi.Areas.UserServices.Controllers
{
    [Authorize]
    [Area("UserServices")]
    public class HolidayTypesController : Controller
    {
        private readonly ApplicationDbContext db;

        public HolidayTypesController(ApplicationDbContext _db)
        {
            this.db = _db;
        }
        public async Task<IActionResult> Index()
        {
            return View(await db.HolidayTypes.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HolidayType model)
        {
            if (ModelState.IsValid)
            {
                await db.HolidayTypes.AddAsync(model);
                await db.SaveChangesAsync();

                return Json(new
                {
                    success = true,
                    message = "Type de congé ajouté !",
                    isValid = true,
                    html = Helper.RenderRazorViewToString(this, "_ViewAll",
                    await db.HolidayTypes.ToListAsync())
                });
            }

            return Json(new
            {
                success = false,
                message = "Addition echoué !",
                isValid = false,
                html = Helper.RenderRazorViewToString(this, "_ViewAll",
                await db.HolidayTypes.ToListAsync())
            });
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var type = await db.HolidayTypes.FindAsync(id);

            if (type == null)
            {
                return NotFound();
            }
            return View(type);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(HolidayType model)
        {
            if (ModelState.IsValid)
            {
                db.HolidayTypes.Update(model);
                await db.SaveChangesAsync();

                return Json(new
                {
                    success = true,
                    message = "Type de congé modifié !",
                    isValid = true,
                    html = Helper.RenderRazorViewToString(this, "_ViewAll",
                    await db.HolidayTypes.ToListAsync())
                });
            }

            return Json(new
            {
                success = false,
                message = "Modification echoué !",
                isValid = false,
                html = Helper.RenderRazorViewToString(this, "_ViewAll",
                await db.HolidayTypes.ToListAsync())
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            HolidayType model = await db.HolidayTypes.FindAsync(id);
            if (model == null)
            {
                return Json(new { success = false, message = "Erreur lors de la suppression !", html = Helper.RenderRazorViewToString(this, "_ViewAll", await db.HolidayTypes.ToListAsync()) });
            }
            db.HolidayTypes.Remove(model);
            await db.SaveChangesAsync();
            return Json(new { success = true, message = "type Congé supprimé !", html = Helper.RenderRazorViewToString(this, "_ViewAll", await db.HolidayTypes.ToListAsync()) });
        }
    }
}
