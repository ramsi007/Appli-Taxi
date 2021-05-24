using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Appli_Taxi.Models.ViewModels
{
    public class TypeAndCategoryViewModel
    {
        public Category Category { get; set; }

        [Display(Name ="Type de catégorie")]
        public IEnumerable<TypeCat> ListTypes { get; set; }
    }
}
