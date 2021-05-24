using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appli_Taxi.Models.ViewModels
{
    public class UserProposalsBillsViewModel
    {
        public ApplicationUser ApplicationUser { get; set; }
        public List<Proposal> ProposalList { get; set; }
    }
}
