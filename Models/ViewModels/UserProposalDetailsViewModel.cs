using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appli_Taxi.Models.ViewModels
{
    public class UserProposalDetailsViewModel
    {
        public Proposal Proposal { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public List<ProposalDetail> ProposalDetailsList { get; set; }
    }
}
