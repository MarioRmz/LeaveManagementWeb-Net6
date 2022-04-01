using LeaveManagement.Web.Data;

namespace LeaveManagement.Web.Contracts
{
    //En este caso, esta interface es relativa a LeaveType si o si
    //Las operaciones que se hagan aca y se pasen al repositorio generico pasaran con el tipo LeaveType
    public interface ILeaveTypeRepository : IGenericRepository<LeaveType>
    {

    }
}
