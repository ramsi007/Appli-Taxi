using Appli_Taxi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Appli_Taxi.Models.ViewModels
{
    public class ProposalCartViewModel
    {
        [Display(Name="Produit")]
        public IEnumerable<Produit> ListProduct { get; set; }
        public ShooppingCart ShooppingCart { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public Proposal Proposal { get; set; }
        public Bill Bill { get; set; }
    }
}
