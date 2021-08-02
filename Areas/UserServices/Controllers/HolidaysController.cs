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
    public class HolidaysController : Controller
    {
        private readonly IEmailSender _emailSender;
        private readonly ApplicationDbContext db;

        public HolidaysController(ApplicationDbContext _db, IEmailSender emailSender)
        {
            this.db = _db;
            _emailSender = emailSender;
        }

        Holiday holiday = new Holiday();

        public async Task<IActionResult> Index()
        {
            IList<Holiday> holidays;
            if (User.IsInRole(SD.ManagerUser))
            {
                holidays = await db.Holidays.Include(m => m.ApplicationUser).Include(m => m.HolidayType).ToListAsync();
            }
            else
            {
                holidays = await db.Holidays.Include(m => m.ApplicationUser)
                    .Include(m => m.HolidayType).Where(m => m.UserId == GetUserId()).ToListAsync();
            }

            var holidayInDemand = await db.Holidays.Where(m => m.Status == SD.StatusInProcess).ToListAsync();
            HttpContext.Session.SetInt32(SD.HolidaysDemandCount, holidayInDemand.Count);

            return View(holidays);
        }

        public async Task<IActionResult> CreateEdit(int id=0)
         {
            if(id <=0)
            {
                holiday.StartDate = Convert.ToDateTime(DateTime.Now.ToString("dd-MMMM-yyyy"));
                holiday.EndDate = Convert.ToDateTime(DateTime.Now.ToString("dd-MMMM-yyyy"));
                holiday.DemandeDate = Convert.ToDateTime(DateTime.Now.ToString("dd-MMMM-yyyy"));

                if(!User.IsInRole(SD.ManagerUser))
                {
                    holiday.UserId = GetUserId();
                }
                
            }
            else
            {
                holiday = await db.Holidays.FindAsync(id);

                if (holiday == null)
                {
                    return NotFound();
                }
            }

            HolidayViewModel HolidayVM = new HolidayViewModel()
            {
                Holiday = holiday,
                ListHolidaysType = await db.HolidayTypes.ToListAsync(),
                ListUsers = selectUsers()
            };

            return View(HolidayVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateEdit(HolidayViewModel model)
        {
            if (ModelState.IsValid)
            {
                if(model.Holiday.Id == 0)
                {
                    await db.Holidays.AddAsync(model.Holiday);
                }else
                {
                 db.Holidays.Update(model.Holiday);
                }

                await db.SaveChangesAsync();

                var holiday = await db.Holidays.FindAsync(model.Holiday.Id);
                var userId = await db.Holidays.Where(m => m.Id == model.Holiday.Id)
                                     .Select(m => m.UserId).SingleOrDefaultAsync();

                var user = await db.ApplicationUsers.Where(m => m.Id == userId).FirstOrDefaultAsync();

                await _emailSender.SendEmailAsync("Marc.grosy@pyrgus.fr", "Confirmer une demande de congé",
                                    "Bonjour : <br/>" +
                                    "Vous avez une nouvelle demande de congé de la part du salarié : " + user.FirstName + " " + user.LastName + "<br/>" +
                                    "Cliquer sur le lien si dessous pour voir les détails de la demande <br/>" +
                                    "https://applitaxi.azurewebsites.net/UserServices/Holidays/Details/" + model.Holiday.Id + "<br/>" + "<hr>" +
                                    "<div class='col-md-12'><div class='row ml-1'>" +
                                    "<span><img class='pb-2' " +
                                    "src='https://is1-ssl.mzstatic.com/image/thumb/Purple118/v4/1b/29/f2/1b29f20e-3004-5715-d070-5356ad545b21/source/512x512bb.jpg' " +
                                    "style='width:200px; height:150px;'/></span>" +
                                    "<p>28 avenue de la résistance <br />91700 Sainte - Genevièves - des - bois <br />" +
                                    "<b> SIRET :</ b > 83138505900017 <br/>France</p>" +
                                    "</div></div>");

                model.Holiday.Status = SD.StatusInProcess;
                db.Holidays.Update(model.Holiday);
                await db.SaveChangesAsync();

                var count = db.Holidays.Where(m => m.Status == SD.StatusInProcess).ToList().Count;
                HttpContext.Session.SetInt32(SD.HolidaysDemandCount, count);

                return Json(new
                {
                    success = true,
                    message = "Votre demande a été bien envoyé !",
                    isValid = true,
                    html = Helper.RenderRazorViewToString(this, "_ViewAll", selectListHoliday())

                });
            }

            HolidayViewModel HolidayVM = new HolidayViewModel()
            {
                Holiday = new Holiday(),
                ListHolidaysType = await db.HolidayTypes.ToListAsync()
            };
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "Create", HolidayVM) });

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            Holiday model = await db.Holidays.FindAsync(id);
            if (model == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Erreur lors de la suppression !",
                    html = Helper.RenderRazorViewToString(this, "_ViewAll", selectListHoliday())
                });
            }
            db.Holidays.Remove(model);
            await db.SaveChangesAsync();
            return Json(new
            {
                success = true,
                message = "Congé supprimé !",
                html = Helper.RenderRazorViewToString(this, "_ViewAll", selectListHoliday())

            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        public async Task<IActionResult> ShowHolidaysinDemand()
        {
            var holidaysInDemand = new List<Holiday>();

            if (User.IsInRole(SD.ManagerUser))
            {
                holidaysInDemand = await db.Holidays.Include(m => m.HolidayType).Include(m => m.ApplicationUser)
                                        .Where(m => m.Status == SD.StatusInProcess).ToListAsync();

            }
            else
            {
                 holidaysInDemand = await db.Holidays.Include(m => m.HolidayType).Include(m => m.ApplicationUser)
                                      .Where(m => m.Status == SD.StatusInProcess && m.UserId == GetUserId()).ToListAsync();
            }
            HttpContext.Session.SetInt32(SD.HolidaysDemandCount, holidaysInDemand.Count);
            return View(holidaysInDemand);
        }

        public async Task<IActionResult> ConfirmCancelHoliday(int confirmId, int cancelId)
        {
            if(confirmId > 0)
            {
                holiday = await db.Holidays.FindAsync(confirmId);
                holiday.Nbdays = confirmId;
            }
            else
            {
                holiday = await db.Holidays.FindAsync(cancelId);
            }

            var holidayType = await db.HolidayTypes.Where(m => m.Id == holiday.TypeId).FirstOrDefaultAsync();
            holiday.HolidayType.Name = holidayType.Name;
            return View(holiday);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("ConfirmCancelHoliday")]
        public async Task<IActionResult> ConfirmCancelHolidayPost(Holiday model)
        {
            holiday = await db.Holidays.FindAsync(model.Id);
            if (model.Nbdays == model.Id)
            {
                holiday.Status = SD.StatusAccepted;
            }
            else
            {
                holiday.Status = SD.StatusDeclined;
            }

            db.Holidays.Update(holiday);
            await db.SaveChangesAsync();

            var holidaysInDemand = new List<Holiday>();

            if (User.IsInRole(SD.ManagerUser))
            {
                holidaysInDemand = await db.Holidays.Include(m => m.HolidayType).Include(m => m.ApplicationUser)
                                        .Where(m => m.Status == SD.StatusInProcess).ToListAsync();

            }
            else
            {
                holidaysInDemand = await db.Holidays.Include(m => m.HolidayType).Include(m => m.ApplicationUser)
                                     .Where(m => m.Status == SD.StatusInProcess && m.UserId == GetUserId()).ToListAsync();
            }
            HttpContext.Session.SetInt32(SD.HolidaysDemandCount, holidaysInDemand.Count);

            return Json(new
            {
                success = true,
                message = "Congé validé !",
                isValid = true,
                html = Helper.RenderRazorViewToString(this, "_Show", holidaysInDemand)
                
            });
        }

        /// <summary>
        ///
        /// </summary>
        /// <param ></param>
        /// <returns></returns>

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var holiday = await db.Holidays.FindAsync(id);
            if (holiday == null)
            {
                return NotFound();
            }

            IList<ApplicationUser> users;

            users = db.ApplicationUsers.Where(m => m.Id == holiday.UserId).ToList();

            HolidayViewModel HolidayVM = new HolidayViewModel()
            {
                Holiday = holiday,
                ListHolidaysType = await db.HolidayTypes.Where(m => m.Id == holiday.TypeId).ToListAsync(),
                ListUsers = users
            };

            return View(HolidayVM);
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

        public IList<Holiday> selectListHoliday()
        {
            IList<Holiday> listHolidays;

            if (User.IsInRole(SD.ManagerUser))
            {
                listHolidays = db.Holidays.Include(m => m.HolidayType).Include(m => m.ApplicationUser).ToList();
            }
            else
            {
                listHolidays = db.Holidays.Include(m => m.HolidayType).Include(m => m.ApplicationUser)
                                .Where(m => m.UserId == GetUserId()).ToList();
            }

            return listHolidays;
        }


    }
}
