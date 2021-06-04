using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Appli_Taxi.Models.ViewModels
{
    public class HolidayViewModel
    {
        public Holiday Holiday { get; set; }
        [Display(Name ="Type de Congé")]
        public IEnumerable<HolidayType> ListHolidaysType { get; set; }
        [Display(Name = "Personnel")]
        public IEnumerable<ApplicationUser> ListUsers { get; set; }
    }
}
