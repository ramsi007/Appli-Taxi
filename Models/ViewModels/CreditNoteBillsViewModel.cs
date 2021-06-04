using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appli_Taxi.Models.ViewModels
{
    public class CreditNoteBillsViewModel
    {
        public IEnumerable<Bill> ListBills { get; set; }
        public CreditNote CreditNote { get; set; }
        public Receipt Receipt { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string NumBill { get; set; }
    }
}
