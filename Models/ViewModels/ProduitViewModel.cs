using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Appli_Taxi.Models.ViewModels
{
    public class ProduitViewModel
    {
        public Produit Produit { get; set; }

        [Display(Name="Catégorie")]
        public IList<Category> CategoriesList { get; set; }

        [Display(Name = "Taxe")]
        public IList<Tax> TaxesList { get; set; }
    }
}
