using Appli_Taxi.Data;
using Appli_Taxi.Models;
using Appli_Taxi.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Appli_Taxi.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ApplicationDbContext db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext _db)
        {
            _logger = logger;
            this.db= _db;
        }

        public IActionResult Index()
        {
            var holidayInDemand = db.Holidays.Where(m => m.Status == SD.StatusInProcess).ToList();
            HttpContext.Session.SetInt32(SD.HolidaysDemandCount, holidayInDemand.Count);

            var expenseInDemand = db.ExpenseReports.Where(m => m.Status == SD.StatusInProcess).ToList();
            HttpContext.Session.SetInt32(SD.ExpensesDemandCount, expenseInDemand.Count);
            return View();
        }

        public IActionResult Privacy()
        {

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
