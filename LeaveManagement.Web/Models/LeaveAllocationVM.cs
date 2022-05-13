using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Web.Models
{
    public class LeaveAllocationVM
    {
        [Required]
        public int Id { get; set; }

        [Display(Name = "Number of Days")]
        [Required]
        [Range(1, 50, ErrorMessage = "Invalid Number Entered")]
        public int NumberOfDays { get; set; }

        [Display(Name = "Allocation Period")]
        [Required]
        public int Period { get; set; }

        //Como se muestra aqui un view model hace parte de otro view model como una propiedad,
        //pero un data model NO debe ser una propiedad 
        //Se cambio a nullable para que no devuelva que el modelo es invalido en vistas como EditAllocation y EmployeesController
        public LeaveTypeVM? LeaveType { get; set; }
    }
}