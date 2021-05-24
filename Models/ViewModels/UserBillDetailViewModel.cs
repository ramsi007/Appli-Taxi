using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appli_Taxi.Models.ViewModels
{
    public class UserBillDetailViewModel
    {
        public Bill Bill { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public List<BillDetail> BillDetailsList { get; set; }
        public List<CreeditNote> CreditNoteList { get; set; }
        public List<Receipt> ReceiptList { get; set; }
    }
}
