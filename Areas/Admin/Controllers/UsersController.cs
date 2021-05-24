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

namespace Appli_taxi.Areas.Admin.Controllers
{
    [Authorize(Roles = SD.ManagerUser)]
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext db;

        public UsersController(ApplicationDbContext _db)
        {
            this.db = _db;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            return View(await db.ApplicationUsers.Where(m => m.Id != claim.Value).ToListAsync());
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await db.ApplicationUsers.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ApplicationUser model)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            var user = await db.ApplicationUsers.FindAsync(model.Id);

            if (ModelState.IsValid)
            {
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.PhoneNumber = model.PhoneNumber;
                user.Email = model.Email;

                var userRole = await db.UserRoles.Where(m => m.UserId == user.Id).FirstOrDefaultAsync();
                var role = await db.Roles.Where(m => m.Id == userRole.RoleId).FirstOrDefaultAsync();

                if (role.Equals(SD.EmployeeUser))
                {
                    user.EmployeeAdresse = model.EmployeeAdresse;
                    user.EmployeeCity = model.EmployeeCity;
                    user.EmployeeCountry = model.EmployeeCountry;
                    user.EmployeePostalCode = model.EmployeePostalCode;
                    user.BirthDate = model.BirthDate;
                    user.HiringDate = model.HiringDate;
                }
                else
                {
                    user.BillingAdresse = model.BillingAdresse;
                    user.BillingCity = model.BillingCity;
                    user.BillingCountry = model.BillingCountry;
                    user.BillingName = model.BillingName;
                    user.BillingPhone = model.BillingPhone;
                    user.BillingPostalCode = model.BillingPostalCode;
                    user.BillingState = model.BillingState;

                    user.ShippingAdresse = model.ShippingAdresse;
                    user.ShippingCity = model.ShippingCity;
                    user.ShippingCountry = model.ShippingCountry;
                    user.ShippingName = model.ShippingName;
                    user.ShippingPhone = model.ShippingPhone;
                    user.ShippingPostalCode = model.ShippingPostalCode;
                    user.ShippingState = model.ShippingState;
                }

                await db.SaveChangesAsync();
                return Json(new
                {
                    success = true,
                    message = "Compte modifié !",
                    isValid = true,
                    html = Helper.RenderRazorViewToString(this, "_ViewAll",
                    await db.ApplicationUsers.Where(m => m.Id != claim.Value).ToListAsync())
                });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Edit", model) });

        }

        public async Task<IActionResult> Customers()
        {
            //   var role = await db.Roles.Where(m => m.Name.Equals(SD.CustomerUser)).FirstOrDefaultAsync();
            //   var CustomerUsers = await db.UserRoles.Where(m => m.RoleId.Equals(role.Id)).ToListAsync();

            //   List<ApplicationUser> Users = new List<ApplicationUser>();
            //   foreach (var item in CustomerUsers)
            //{
            //       var user = await db.ApplicationUsers.FindAsync(item.UserId);
            //       Users.Add(user);
            //}

            var users = await db.ApplicationUsers.Where(m => m.UserRole == SD.CustomerUser).ToListAsync();

            return View(users);
        }


        public async Task<IActionResult> Vendors()
        {

            var users = await db.ApplicationUsers.Where(m => m.UserRole == SD.VendorUser).ToListAsync();
            return View(users);
        }


        public async Task<IActionResult> Employees()
        {

            var users = await db.ApplicationUsers.Where(m => m.UserRole == SD.EmployeeUser).ToListAsync();
            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            UserProposalsBillsViewModel UserPropBillVM = new UserProposalsBillsViewModel()
            {
                ApplicationUser = await db.ApplicationUsers.FindAsync(id),
                ProposalList = await db.Proposals.Include(m => m.ApplicationUser).Where(m => m.UserId == id)
                                .ToListAsync()
            };

            return View(UserPropBillVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            var user = db.ApplicationUsers.Find(id);

            if (user == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Erreur lors de la suppression !",
                    html = Helper.RenderRazorViewToString(this, "_ViewAll", await db.ApplicationUsers.Where(m => m.Id != claim.Value).ToListAsync())
                }); ;
            }
            db.ApplicationUsers.Remove(user);
            await db.SaveChangesAsync();
            return Json(new
            {
                success = true,
                message = "Proposition supprimé !",
                html = Helper.RenderRazorViewToString(this, "_ViewAll",
                await db.ApplicationUsers.Where(m => m.Id != claim.Value).ToListAsync())
            });
        }

        public async Task<IActionResult> LockUnLock(string id)
        {
            if (id == null)
            {

                return NotFound();
            }

            var user = await db.ApplicationUsers.FindAsync(id);

            if (user == null)
            {

                return NotFound();
            }

            if (user.LockoutEnd == null || user.LockoutEnd < DateTime.Now)
            {
                user.LockoutEnd = DateTime.Now.AddYears(1000);
            }
            else
            {
                user.LockoutEnd = DateTime.Now;
            }
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }

}
