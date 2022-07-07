using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Common.Models
{
    public class AdminLeaveRequestViewVM
    {
        [Display(Name = "Total de Solicitudes")]
        public int TotalRequests { get; set; }

        [Display(Name = "Solicitudes Aprobadas")]
        public int ApprovedRequests { get; set; }

        [Display(Name = "Solicitudes Pendientes")]
        public int PendingRequests { get; set; }

        [Display(Name = "Solicitudes Rechazadas")]
        public int RejectedRequests { get; set; }

        public List<LeaveRequestVM> LeaveRequests { get; set; }
    }
}
