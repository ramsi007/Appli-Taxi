using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Appli_Taxi.Models
{
    public class Tax
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="ce champ est obligatoire"), Display(Name ="Nom de la Taxe")]
        public string Name { get; set; }

        [Required(ErrorMessage = "ce champ est obligatoire"), Display(Name = "Taux%")]
        public double Discount { get; set; }
    }
}
