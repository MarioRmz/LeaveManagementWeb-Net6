using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Web.Models
{
    public class LeaveRequestCreateVM : IValidatableObject
    {
        //Al hacer que los campos DateTime se vuelvan nullable evita que en sus 
        //respectivos datepickers aparezcan fechas default
        [Required]
        [Display(Name = "Fecha Inicio")]
        public DateTime? StartDate { get; set; }

        [Required]
        [Display(Name = "Fecha Fin")]
        public DateTime? EndDate { get; set; }
        
        [Required]
        [Display(Name = "Leave Type")]
        public int LeaveTypeId { get; set; }

        //Dropdownlist de la vista
        public SelectList? LeaveTypes { get; set; }

        [Display(Name = "Comentarios")]
        public string? RequestComments { get; set; }

        //Implementacion de IValidatableObject
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //Custom validation para cuando la fecha inicio es mayor a fecha fin
            if (StartDate > EndDate)
            {
                yield return new ValidationResult("La Fecha de Inicio debe ser antes de la Fecha Fin",
                    new[] { nameof(StartDate), nameof(EndDate) });
            }

            //Custom validation para revisar la longitud de los comentarios
            if (RequestComments?.Length > 250)
            {
                yield return new ValidationResult("Los Comentarios son muy largos",
                    new[] { nameof(RequestComments) });
            }
        }
    }
}
