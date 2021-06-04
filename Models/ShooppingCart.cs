using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Appli_Taxi.Models
{
    public class ShooppingCart
    {
        public ShooppingCart()
        {
            Count = 1;
        }

        [Key]
        public int Id { get; set; }

        public string ApplicationUserId { get; set; }
        [NotMapped]
        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }

        public int ProduitId { get; set; }
        [NotMapped]
        [ForeignKey("ProduitId")]
        public virtual Produit Produit { get; set; }

        [Display(Name = "Quantité")]
        [Range(1, int.MaxValue, ErrorMessage = "La valeur doit être supérieur ou égal à 1")]
        public int Count { get; set; }

        [Required]
        public double Remise { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        public string NumProposal { get; set; }
        public string NumBill { get; set; }

        [Display(Name = "Prix")]
        //[DisplayFormat(DataFormatString = "{0:C}")]
        public double Price { get; set; }

        [Display(Name = "Taxe")]
        //[DisplayFormat(DataFormatString = "{0:C}")]
        public double Tax { get; set; }

        [Display(Name = "Montant")]
        public double Montant { get; set; }
    }
}
