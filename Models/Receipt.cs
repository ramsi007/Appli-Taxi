using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Appli_Taxi.Models
{
    public class Receipt
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Entrez une référence du reçu")]
        public string Reference { get; set; }

        public DateTime RecieptDate { get; set; }

        [Required(ErrorMessage = "Le montant est obligatoire")]
        public double Montant { get; set; }

        public string Description { get; set; }

        public int BillId { get; set; }
        [ForeignKey("BillId")]
        public virtual Bill Bill { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
