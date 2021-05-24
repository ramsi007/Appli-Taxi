using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Appli_Taxi.Models
{
    public class ExpenseReport
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "La date est obligatoire")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Veuillez remplier le montant de cette note")]
        public double Montant { get; set; }

        [Required(ErrorMessage ="Veuillez remplier le motif de cette note")]
        [Display(Name = "Motif")]
        public string Comment { get; set; }

        public string Status { get; set; }

        public int ConfirmId { get; set; }

        [Display(Name = "Salarié")]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
