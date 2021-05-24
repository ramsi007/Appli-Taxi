using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Appli_Taxi.Models
{
    public class Contrat
    {
        public int Id { get; set; }
        public string Reference { get; set; }

        [Display(Name = "Contrat")]
        public byte[] Path { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
