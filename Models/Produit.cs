using Appli_Taxi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Appli_Taxi.Models
{
    public class Produit
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire"), Display(Name = "Nom")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire"), Display(Name="Prix de vente")]
        //[DisplayFormat(DataFormatString = "{0:C}")]
        //[Range(1, int.MaxValue, ErrorMessage = " Prix de vente ne doit pas être inférieur à {1}€")]
        public double SalePrice { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire"), Display(Name = "Prix d'achat")]
        //[DisplayFormat(DataFormatString = "{0:C}")]
        //[Range(1, int.MaxValue, ErrorMessage = " Prix d'achat ne doit pas être inférieur à {1}€")]
        public double PurchasePrice { get; set; }

        [Display(Name = "Type")]
        public string TypePS { get; set; }
        public enum EType { Produit = 0, Service = 1 }

        [Display(Name = "Catégorie")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [Display(Name = "Taxe")]
        public int TaxId { get; set; }
        [ForeignKey("TaxId")]
        public virtual Tax Tax { get; set; }
    }
}
