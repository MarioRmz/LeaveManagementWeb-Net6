using AutoMapper;
using LeaveManagement.Web.Data;
using LeaveManagement.Web.Models;

namespace LeaveManagement.Web.Configuration
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            //Esto especifica que es legal/posible convertir de LeaveType a LeaveTypeVM y viceversa
            CreateMap<LeaveType, LeaveTypeVM>().ReverseMap();

            //Esto especifica que es legal/posible convertir de Employee a EmployeeListVM y viceversa
            CreateMap<Employee, EmployeeListVM>().ReverseMap();

            //De Employee a EmployeAllocationVM y viceversa
            CreateMap<Employee, EmployeeAllocationVM>().ReverseMap();

            //De LeaveAllocation a LeaveAllocationVM y viceversa
            CreateMap<LeaveAllocation, LeaveAllocationVM>().ReverseMap();

            //De LeaveAllocation a LeaveAllocationEditVM y viceversa
            CreateMap<LeaveAllocation, LeaveAllocationEditVM>().ReverseMap();

            //De LeaveRequest a LeaveRequestCreateVM y viceversa
            CreateMap<LeaveRequest, LeaveRequestCreateVM>().ReverseMap();

            //De LeaveRequest a LeaveRequestVM
            CreateMap<LeaveRequest, LeaveRequestVM>().ReverseMap();
        }
    }
}
