using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Appli_Taxi.Models.ViewModels
{
    public class CreditNoteBillsViewModel
    {
        [Display(Name ="Facture")]
        public IEnumerable<Bill> ListBills { get; set; }
        public CreeditNote CreditNote { get; set; }
        public Receipt Receipt { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public Bill Bill { get; set; }
        public string StatusMessage { get; set; }
    }
}
