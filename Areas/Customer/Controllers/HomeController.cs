using Appli_taxi.Utility;
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

namespace Appli_taxi.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ApplicationDbContext db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext _db)
        {
            _logger = logger;
            this.db = _db;
        }

        public IActionResult Index()
        {
            var customers = db.ApplicationUsers.Where(m => m.UserRole.Equals(SD.CustomerUser)).ToList();
            ViewBag.Customer = customers;

            var vendors = db.ApplicationUsers.Where(m => m.UserRole.Equals(SD.VendorUser)).ToList();
            ViewBag.Vendor = vendors;

            var employees = db.ApplicationUsers.Where(m => m.UserRole.Equals(SD.EmployeeUser)).ToList();
            ViewBag.Employee = employees;

            var bills = db.Bills.ToList();
            ViewBag.Bill = bills;

            var proposals = db.Proposals.ToList();
            ViewBag.Proposal = proposals;


            var holidayInDemand = db.Holidays.Where(m => m.Status == SD.StatusInProcess).ToList();
            HttpContext.Session.SetInt32(SD.HolidaysDemandCount, holidayInDemand.Count);

            var expenseInDemand = db.ExpenseReports.Where(m => m.Status == SD.StatusInProcess).ToList();
            HttpContext.Session.SetInt32(SD.ExpensesDemandCount, expenseInDemand.Count);
            return View();
        }


        /// <summary>
        /// 

        [HttpGet]
        public JsonResult BillsLineChart()
        {
            var billList = GetBillsByStatus();
            return Json(billList);
        }

        [HttpGet]
        public IActionResult GetBillsByStatus()
        {
            int paidBills = db.Bills.Where(m => m.Status.Equals(SD.StatusPaid)).Count();
            int notPaidBills = db.Bills.Where(m => m.Status.Equals(SD.StatusNotPaid)).Count();
            int prePaidBills = db.Bills.Where(m => m.Status.Equals(SD.StatusPrePaid)).Count();

            Ratio obj = new Ratio();
            obj.PaidBills = paidBills;
            obj.NotPaidBills = notPaidBills;
            obj.PrePaidBills = prePaidBills;

            return new JsonResult(obj);
        }



        /// </summary>
        /// <returns></returns>
        /// 


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
