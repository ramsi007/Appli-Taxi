using Appli_Taxi.Data;
using Appli_Taxi.Models;
using Appli_Taxi.Models.ViewModels;
using Appli_Taxi.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Appli_Taxi.Areas.UserServices.Controllers
{
    [Authorize]
    [Area("UserServices")]
    public class ExpenseReportsController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly IEmailSender _emailSender;

        public ExpenseReportsController(ApplicationDbContext _db, IEmailSender emailSender)
        {
            this.db = _db;
            this._emailSender = emailSender;
        }

        ExpenseReport expense = new ExpenseReport();

        public async Task<IActionResult> Index()
        {
            IList<ExpenseReport> listExpenses;
            if (User.IsInRole(SD.ManagerUser))
            {
                listExpenses = await db.ExpenseReports.Include(m => m.ApplicationUser).ToListAsync();
            }
            else
            {
                listExpenses = await db.ExpenseReports.Include(m => m.ApplicationUser)
                    .Where(m => m.UserId == GetUserId()).ToListAsync();
            }

            return View(listExpenses);
        }

        public async Task<IActionResult> CreateEdit(int id = 0)
        {
            if (id <= 0)
            {
                expense.Date = Convert.ToDateTime(DateTime.Now.ToString("dd-MMMM-yyyy"));

                if (!User.IsInRole(SD.ManagerUser))
                {
                    expense.UserId = GetUserId();
                }
            }
            else
            {
                expense = await db.ExpenseReports.FindAsync(id);

                if (expense == null)
                {
                    return NotFound();
                }
            }

            ExpenseUserViewModel ExpenseUserVM = new ExpenseUserViewModel()
            {
                ExpenseReport = expense,
                ListUsers = selectUsers()
            };

            return View(ExpenseUserVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEdit(ExpenseUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.ExpenseReport.Id == 0)
                {
                    await db.ExpenseReports.AddAsync(model.ExpenseReport);
                }
                else
                {
                    db.ExpenseReports.Update(model.ExpenseReport);
                }

                await db.SaveChangesAsync();

                var expense = await db.ExpenseReports.FindAsync(model.ExpenseReport.Id);
                var userId = await db.ExpenseReports.Where(m => m.Id == model.ExpenseReport.Id)
                                     .Select(m => m.UserId).SingleOrDefaultAsync();

                var user = await db.ApplicationUsers.Where(m => m.Id == userId).FirstOrDefaultAsync();

                await _emailSender.SendEmailAsync("Marc.grosy@pyrgus.fr", "Confirmer une note de frais",
                                    "Bonjour : <br/>" +
                                    "Vous avez une nouvelle demande de congé de la part du salarié : " + user.FirstName + " " + user.LastName + "<br/>" +
                                    "Cliquer sur le lien si dessous pour voir les détails de la demande <br/>" +
                                    "https://applitaxi.azurewebsites.net/UserServices/ExpenseReports/Details/" + model.ExpenseReport.Id + "<br/>" + "<hr>" +
                                    "<div class='col-md-12'><div class='row ml-1'>" +
                                    "<span><img class='pb-2' " +
                                    "src='https://is1-ssl.mzstatic.com/image/thumb/Purple118/v4/1b/29/f2/1b29f20e-3004-5715-d070-5356ad545b21/source/512x512bb.jpg' " +
                                    "style='width:200px; height:150px;'/></span>" +
                                    "<p>28 avenue de la résistance <br />91700 Sainte - Genevièves - des - bois <br />" +
                                    "<b> SIRET :</ b > 83138505900017 <br/>France</p>" +
                                    "</div></div>");

                model.ExpenseReport.Status = SD.StatusInProcess;
                db.ExpenseReports.Update(model.ExpenseReport);
                await db.SaveChangesAsync();

                var count = db.ExpenseReports.Where(m => m.Status == SD.StatusInProcess).ToList().Count;
                HttpContext.Session.SetInt32(SD.HolidaysDemandCount, count);

                return Json(new
                {
                    success = true,
                    message = "Votre demande a été bien envoyé !",
                    isValid = true,
                    html = Helper.RenderRazorViewToString(this, "_ViewAll", selectListExpenses())

                });
            }

            ExpenseUserViewModel ExpenseUserVM = new ExpenseUserViewModel()
            {
                ExpenseReport = new ExpenseReport(),
            };
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Create", ExpenseUserVM) });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            ExpenseReport model = await db.ExpenseReports.FindAsync(id);
            if (model == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Erreur lors de la suppression !",
                    html = Helper.RenderRazorViewToString(this, "_ViewAll", selectListExpenses())
                });
            }
            db.ExpenseReports.Remove(model);
            await db.SaveChangesAsync();
            return Json(new
            {
                success = true,
                message = "Note de frais supprimé !",
                html = Helper.RenderRazorViewToString(this, "_ViewAll", selectListExpenses())
            });
        }

        /// Show ExpenseReports
        public async Task<IActionResult> ShowExpensesinDemand()
        {
            var ExpenseInDemand = new List<ExpenseReport>();

            if (User.IsInRole(SD.ManagerUser))
            {
                ExpenseInDemand = await db.ExpenseReports.Include(m => m.ApplicationUser)
                                        .Where(m => m.Status == SD.StatusInProcess).ToListAsync();

            }
            else
            {
                ExpenseInDemand = await db.ExpenseReports.Include(m => m.ApplicationUser)
                                     .Where(m => m.Status == SD.StatusInProcess && m.UserId == GetUserId()).ToListAsync();
            }
            HttpContext.Session.SetInt32(SD.ExpensesDemandCount, ExpenseInDemand.Count);
            return View(ExpenseInDemand);
        }


        /// <summary>
        /// 

        public async Task<IActionResult> ConfirmCancelExpense(int confirmId, int cancelId)
        {
            if (confirmId > 0)
            {
                expense = await db.ExpenseReports.FindAsync(confirmId);
                expense.ConfirmId = confirmId;
            }
            else
            {
                expense = await db.ExpenseReports.FindAsync(cancelId);
            }

            return View(expense);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("ConfirmCancelExpense")]
        public async Task<IActionResult> ConfirmCancelExpensePost(ExpenseReport model)
        {
            expense = await db.ExpenseReports.FindAsync(model.Id);
            if (model.ConfirmId == model.Id)
            {
                expense.Status = SD.StatusAccepted;
            }
            else
            {
                expense.Status = SD.StatusDeclined;
            }

            db.ExpenseReports.Update(expense);
            await db.SaveChangesAsync();

            var expenseInDemand = new List<ExpenseReport>();

            if (User.IsInRole(SD.ManagerUser))
            {
                expenseInDemand = await db.ExpenseReports.Include(m => m.ApplicationUser)
                                        .Where(m => m.Status == SD.StatusInProcess).ToListAsync();
                HttpContext.Session.SetInt32(SD.ExpensesDemandCount, expenseInDemand.Count);
            }
            else
            {
                expenseInDemand = await db.ExpenseReports.Include(m => m.ApplicationUser)
                                     .Where(m => m.Status == SD.StatusInProcess && m.UserId == GetUserId()).ToListAsync();
            }

            return Json(new
            {
                success = true,
                message = "Congé validé !",
                isValid = true,
                html = Helper.RenderRazorViewToString(this, "_Show", expenseInDemand)

            });
        }



        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expense = await db.ExpenseReports.FindAsync(id);
            if (expense == null)
            {
                return NotFound();
            }

            ExpenseUserViewModel ExpenseUserVM = new ExpenseUserViewModel()
            {
                ExpenseReport = expense,
                ListUsers = await db.ApplicationUsers.Where(m => m.Id == expense.UserId).ToListAsync()
            };

            return View(ExpenseUserVM);
        }

        public string GetUserId()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            return claim.Value;
        }

        public IList<ApplicationUser> selectUsers()
        {
            IList<ApplicationUser> users = new List<ApplicationUser>();

            var role = db.Roles.Where(m => m.Name.Equals(SD.EmployeeUser)).FirstOrDefault();
            var EmployeesUsers = db.UserRoles.Where(m => m.RoleId.Equals(role.Id)).ToList();

            foreach (var item in EmployeesUsers)
            {
                var user = db.ApplicationUsers.Find(item.UserId);
                users.Add(user);
            }

            return users;
        }

        public IList<ExpenseReport> selectListExpenses()
        {
            IList<ExpenseReport> listExpenses;

            if (User.IsInRole(SD.ManagerUser))
            {
                listExpenses = db.ExpenseReports.Include(m => m.ApplicationUser).ToList();
            }
            else
            {
                listExpenses = db.ExpenseReports.Include(m => m.ApplicationUser)
                                .Where(m => m.UserId == GetUserId()).ToList();
            }

            return listExpenses;
        }
    }

}
