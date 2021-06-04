using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Appli_Taxi.Models.ViewModels
{
    public class ProposalDetailsViewModel
    {
        [Display(Name ="Client")]
        public IList<ApplicationUser> UsersList { get; set; }

        [Display(Name = "Article")]
        public IList<Produit> ProductsList { get; set; }
        public ProposalDetail ProposalDetail { get; set; }
        public Proposal Proposal { get; set; }
        public List<ShooppingCart> ListShoppingCarts { get; set; }
        public ShooppingCart ShooppingCart{ get; set; }
        public ApplicationUser ApplicationUser{ get; set; }
    }
}
