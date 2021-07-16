using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Appli_Taxi.Models
{
    public class ProposalDetail
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ProposalId { get; set; }
        [ForeignKey("ProposalId")]
        public virtual Proposal Proposal { get; set; }

        [Required]
        public int ProduitId { get; set; }
        //[ForeignKey("ProduitId")]
        //public virtual Produit Produit { get; set; }

        public double Remise { get; set; }

        [Display(Name="Quantité")]
        public int Count { get; set; }

        [Display(Name = "Nom")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Prix")]
        //[DisplayFormat(DataFormatString = "{0:C}")]
        public double Price { get; set; }

        [Display(Name = "Taxe")]
        //[DisplayFormat(DataFormatString = "{0:C}")]
        public double Tax { get; set; }
    }
}
