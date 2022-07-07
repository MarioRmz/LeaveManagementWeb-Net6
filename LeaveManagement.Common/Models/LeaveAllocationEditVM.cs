namespace LeaveManagement.Common.Models
{
    public class LeaveAllocationEditVM : LeaveAllocationVM
    {
        public string EmployeeId { get; set; }
        public int LeaveTypeId { get; set; }
        
        //Se cambio a nullable para que no devuelva que el modelo es invalido en vistas como EditAllocation y EmployeesController
        public EmployeeListVM? Employee { get; set; }
    }
}
