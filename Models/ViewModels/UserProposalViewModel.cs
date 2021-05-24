using Appli_Taxi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Appli_Taxi.Models.ViewModels
{
    public class UserProposalViewModel
    {
        public Bill Bill { get; set; }
        public Proposal Proposal { get; set; }
        [Display(Name =" Client")]
        public IEnumerable<ApplicationUser> ListUsers { get; set; }
        public IEnumerable<ShooppingCart> ListShoopingCart { get; set; }
    }
}
