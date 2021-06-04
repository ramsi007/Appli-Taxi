using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Appli_Taxi.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Display(Name = "Nom")]
        public string FirstName { get; set; }

        [Display(Name = "Prénom")]
        public string LastName { get; set; }

        public string BillingName { get; set; }
        public string BillingPostalCode { get; set; }
        public string BillingCity { get; set; }
        public string BillingPhone { get; set; }
        public string BillingState { get; set; }
        public string BillingCountry { get; set; }
        public string BillingAdresse { get; set; }

        public string ShippingName { get; set; }
        public string ShippingPostalCode { get; set; }
        public string ShippingCity { get; set; }
        public string ShippingPhone { get; set; }
        public string ShippingState { get; set; }
        public string ShippingCountry { get; set; }
        public string ShippingAdresse { get; set; }

        [Display(Name ="Code Postal")]
        public string EmployeePostalCode { get; set; }

        [Display(Name = "Ville")]
        public string EmployeeCity { get; set; }

        [Display(Name = "Pays")]
        public string EmployeeCountry { get; set; }

        [Display(Name = "Adresse")]
        public string EmployeeAdresse { get; set; }

        public string UserRole { get; set; }

    }
}
