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
        }
    }
}
