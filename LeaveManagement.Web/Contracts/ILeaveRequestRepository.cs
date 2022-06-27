using LeaveManagement.Web.Data;
using LeaveManagement.Web.Models;

namespace LeaveManagement.Web.Contracts
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        //Se crea esta task para no tenerla en el controller de LeaveRequest, asi tambien no tiene que mappear el controller
        Task<bool> CreateLeaveRequest(LeaveRequestCreateVM request);

        Task<EmployeeLeaveRequestViewVM> GetMyLeaveDetails();

        Task<LeaveRequestVM?> GetLeaveRequestAsync(int? id);

        Task<List<LeaveRequestVM>> GetAllAsync(string employeeId);

        Task ChangeApprovalStatus(int leaveRequestId, bool approved);

        Task CancelLeaveRequest(int leaveRequestId);

        Task<AdminLeaveRequestViewVM> GetAdminLeaveRequestList();
    }
}
