using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Appli_Taxi.Models
{
    public class Bill
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Facture N° ")]
        public string NumBill { get; set; }

        [Display(Name = "Client ")]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Required]
        [Display(Name = "Date de D'émission")]
        public DateTime IssueDate { get; set; }

        [Display(Name = "Date d'échéance")]
        public DateTime DueDate { get; set; }

        [Required]
        [Display(Name = "Prix total HT")]
        public double BillTotalOrginal { get; set; }

        [Required]
        //[DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Prix total TTC")]
        public double BillTotal { get; set; }

        //[DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Note de crédit")]
        public double Remise { get; set; }

        [Display(Name = "Payé")]
        public double Paid { get; set; }

        [Display(Name = "Reste")]
        public double Rest { get; set; }

        [Display(Name = "type de Proposition")]
        public string BillType { get; set; }
        public enum PrType
        {
            Maintenance = 0,
            Product = 1
        }

        public string Status { get; set; }

        [Display(Name = "N° Téléphone")]
        public string PhoneNumber { get; set; }

        public string TransactionId { get; set; }
    }
}
