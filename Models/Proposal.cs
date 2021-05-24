using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Appli_Taxi.Models
{
    public class Proposal
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Propostion N° ")]
        public string NumProposal { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Required]
        [Display(Name = "Date de proposition")]
        public DateTime ProposalDate { get; set; }

        [Required]
        //[DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Prix total HT")]
        public double ProposalTotalOrginal { get; set; }

        [Required]
        //[DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Prix total TTC")]
        public double ProposalTotal { get; set; }

        //[DisplayFormat(DataFormatString = "{0:C}")]
        [Display(Name = "Remise")]
        public double Remise { get; set; }

        [Display(Name = "type de Proposition")]
        public string PoposalType { get; set; }
        public enum PrType
        {
            Maintenance = 0,
            Produit = 1
        }

        public string Status { get; set; }

        [Display(Name = "N° Téléphone")]
        public string PhoneNumber { get; set; }

        public string TransactionId { get; set; }
    }
}
