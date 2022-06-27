using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Web.Models
{
    public class EmployeeListVM
    {
        public string Id { get; set; }

        [Display(Name = "Nombre")]
        public string Firstname { get; set; }

        [Display(Name = "Apellido")]
        public string Lastname { get; set; }

        [Display(Name = "Fecha Ingreso")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime DateJoined { get; set; }

        [Display(Name = "Direccion Email")]
        public string Email { get; set; }
    }
}
