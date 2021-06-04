using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appli_Taxi.Models.ViewModels
{
    public class ProposalIndexViewModel
    {
        public IList<Proposal> ProposalList { get; set; }
        public IList<ShooppingCart> ShoopingCartList { get; set; }
    }
}
