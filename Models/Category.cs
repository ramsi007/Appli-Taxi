using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Appli_Taxi.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Veuillez entrer le nom du catégorie")
                                 ,Display(Name = "Nom de catégorie")]
        public string Name { get; set; }


        public int TypeId { get; set; }
        [ForeignKey("TypeId")]
        public virtual TypeCat TypeCat { get; set; }
    }
}
