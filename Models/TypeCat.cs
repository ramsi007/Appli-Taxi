using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Appli_Taxi.Models
{
    public class TypeCat
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Veuillez entrer un type"), Display(Name ="Type")]
        public string Name { get; set; }
    }
}
