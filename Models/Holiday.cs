using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Appli_Taxi.Models
{
    public class Holiday
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Date de demande")]
        public DateTime DemandeDate { get; set; }

        [Required]
        [Display(Name = "Date de début")] 
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "Date de fin")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Jours restants")]
        public int Nbdays { get; set; }

        [Display(Name = "Motif de Demande")]
        public string Comment { get; set; }

        public string Status { get; set; }

        [Display(Name = "Type")]
        public int TypeId { get; set; }
        [ForeignKey("TypeId")]
        public virtual HolidayType HolidayType { get; set; }

        [Display(Name = "Salarié")]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
