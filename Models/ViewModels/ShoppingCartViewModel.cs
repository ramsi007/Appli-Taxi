using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appli_Taxi.Models.ViewModels
{
    public class ShoppingCartViewModel
    {
        public IEnumerable<ShooppingCart> ListProposalShooppingCarts { get; set; }
        public IEnumerable<ShooppingCart> ListBilllShooppingCarts { get; set; }
        public IList<Produit> ListProducts { get; set; }
        public ApplicationUser User { get; set; }
    }
}
