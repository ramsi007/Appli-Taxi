using Appli_Taxi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appli_Taxi.Utility
{
    public static class SD
    {
        public const string ManagerUser = "Administrateur";
        public const string VendorUser = "Fournisseur";
        public const string CustomerUser = "Client";
        public const string EmployeeUser = "Employee";

        public const string StatusOpen = "ouvert";
        public const string StatusInProcess = "en cours de traitement";
        public const string StatusAccepted = "accepté";
        public const string StatusDeclined = "refusé";
        public const string StatusCompleted = "terminé";
        public const string StatusSend = "Envoyé";
        public const string StatusCanceled = "annulé";
        public const string StatusNotPaid = "Non Payé";
        public const string StatusPaid = "Payé";
        public const string StatusPrePaid = "Partiellement payé";

        public const string HolidaysDemandCount = "HolidaysDemandCount";
        public const string ExpensesDemandCount = "ExpensesDemandCount";
        public const string ShoopingCartCount = "ShoopingCartCount";

    }




}
