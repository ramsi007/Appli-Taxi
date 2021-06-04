using Appli_Taxi.Data;
using Appli_Taxi.Models;
using Appli_Taxi.Models.ViewModels;
using Appli_Taxi.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Appli_Taxi.Areas.Admin.Controllers
{

    [Authorize(Roles = SD.ManagerUser)]
    [Area("Admin")]
    public class ContratsController : Controller
    {
        private readonly ApplicationDbContext db;

        public ContratsController(ApplicationDbContext _db)
        {
            this.db = _db;
        }

        public async Task<IActionResult> Index()
        {
            IList<Contrat> listContrats = new List<Contrat>();

            if (User.IsInRole(SD.ManagerUser))
            {
                 listContrats = await db.Contrats.Include(m => m.ApplicationUser).ToListAsync();
            }
            else
            {
                listContrats = await db.Contrats.Include(m => m.ApplicationUser)
                              .Where(m =>m.ApplicationUser.Id == GetUserId()).ToListAsync();
            }
            return View(listContrats);
        }

        public async Task<IActionResult> Create(string id)
        {
            Contrat contrat = new Contrat();
            contrat.Reference = (" #Ctr-" + DateTime.Now.ToFileTime().ToString()).Substring(1, 18);
            contrat.UserId = id;
            UserContratViewModel UserContratVM = new UserContratViewModel()
            {
                Contrat = contrat,
                ApplicationUser = await db.ApplicationUsers.Where(m =>m.Id == id)
                                    .FirstOrDefaultAsync()
            };
            return View(UserContratVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UserContratViewModel model)
        {
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;

                if (files.Count > 0)
                {
                    byte[] ctrFile = null;
                    var fs = files[0].OpenReadStream();
                    var ms = new MemoryStream();
                    fs.CopyTo(ms);
                    ctrFile = ms.ToArray();
                    model.Contrat.Path = ctrFile;
                }
                await db.Contrats.AddAsync(model.Contrat);
                await db.SaveChangesAsync();

                return RedirectToAction("Details","Users", new { id = model.Contrat.UserId});
            }

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            Contrat model = db.Contrats.Find(id);
            if (model == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Erreur lors de la suppression !",
                    html = Helper.RenderRazorViewToString(this, "_ViewAll", await db.Proposals.Include(m => m.ApplicationUser).ToListAsync())
                });
            }
            db.Contrats.Remove(model);
            await db.SaveChangesAsync();
            return Json(new
            {
                success = true,
                message = "Contrat supprimé !",
                html = Helper.RenderRazorViewToString(this, "_ViewAll", await db.Contrats.Include(m => m.ApplicationUser).ToListAsync())
            });
        }

        public string GetUserId()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            return claim.Value;
        }

    }
}
