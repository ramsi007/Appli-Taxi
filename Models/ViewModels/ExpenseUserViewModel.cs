using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appli_Taxi.Models.ViewModels
{
    public class ExpenseUserViewModel
    {
        public ExpenseReport ExpenseReport { get; set; }
        public IEnumerable<ApplicationUser> ListUsers { get; set; }
    }
}
