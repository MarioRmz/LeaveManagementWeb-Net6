using AutoMapper;
using AutoMapper.QueryableExtensions;
using LeaveManagement.Web.Contracts;
using LeaveManagement.Web.Data;
using LeaveManagement.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Web.Repositories
{
    //Implementacion
    //Esto va a ser relativo a LeaveRequest y al mismo tiempo heredara de ILeaveRequestRepository
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        //Inyeccion de mapper, httpcontextaccesor y el usermanager
        //Al usar inyecciones evitamos manejar siempre de manera directa el context, asi que mantenemos esa 
        //consistencia siempre inyectando mas cosas que se necesiten
        //Pero eventualmente no se puede reutilizar todo, por lo que aqui si necesitaremos al context
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ILeaveAllocationRepository leaveAllocationRepository;
        private readonly AutoMapper.IConfigurationProvider configurationProvider;
        private readonly UserManager<Employee> userManager;
        private readonly ApplicationDbContext context;
        public LeaveRequestRepository(ApplicationDbContext context,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor,
            ILeaveAllocationRepository leaveAllocationRepository,
            AutoMapper.IConfigurationProvider configurationProvider,
            UserManager<Employee> userManager) : base(context)
        {
            this.context = context;
            this.mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            this.leaveAllocationRepository = leaveAllocationRepository;
            this.configurationProvider = configurationProvider;
            this.userManager = userManager;
        }

        public async Task CancelLeaveRequest(int leaveRequestId)
        {
            //Consultamos y cancelamos la solicitud
            var leaveRequest = await GetAsync(leaveRequestId);
            leaveRequest.Cancelled = true;
            await UpdateAsync(leaveRequest);
        }

        public async Task ChangeApprovalStatus(int leaveRequestId, bool approved)
        {
            //Primero traemos la request por medio del id y le asignamos el estatus
            var leaveRequest = await GetAsync(leaveRequestId);
            leaveRequest.Approved = approved;

            if (approved)
            {
                //Se busca el allocation y se calculan los dias totales solicitados
                var allocation = await leaveAllocationRepository.GetEmployeeAllocation(leaveRequest.RequestingEmployeeId, leaveRequest.LeaveTypeId);
                int daysRequested = (int)(leaveRequest.EndDate - leaveRequest.StartDate).TotalDays;
                allocation.NumberOfDays -= daysRequested;

                //Se actualiza el registro
                await leaveAllocationRepository.UpdateAsync(allocation);
            }

            //Se actualiza el leaveRequest incluso si no fue aprobada
            await UpdateAsync(leaveRequest);
        }

        public async Task<bool> CreateLeaveRequest(LeaveRequestCreateVM model)
        {
            //Consultamos al usuario asociado con esta request
            var user = await userManager.GetUserAsync(httpContextAccessor?.HttpContext?.User);

            //Consultamos la allocation y calculamos los dias solicitados
            var leaveAllocation = await leaveAllocationRepository.GetEmployeeAllocation(user.Id, model.LeaveTypeId);
            if (leaveAllocation == null)
            {
                return false;
            } 
            int daysRequested = (int)(model.EndDate.Value - model.StartDate.Value).TotalDays;

            //Si los dias solicitados son mayores a los dias de la solicitud, entonces devolvemos false
            if (daysRequested > leaveAllocation.NumberOfDays)
            {
                return false;
            }

            //Mapeamos el modelo desde el view model a la entidad leave request, y ahi seteamos info default
            var leaveRequest = mapper.Map<LeaveRequest>(model);
            leaveRequest.DateRequested = DateTime.Now;
            leaveRequest.RequestingEmployeeId = user.Id;

            //Agregamos el nuevo request
            await AddAsync(leaveRequest);
            return true;
        }

        public async Task<AdminLeaveRequestViewVM> GetAdminLeaveRequestList()
        {
            //Consultando las requests llenamos el constructor de AdminLeaveRequestViewVM
            //A GetAllAsync le faltan algunos datos, asi que mejor consultamos directamente
            //var leaveRequests = await GetAllAsync();
            var leaveRequests = await context.LeaveRequests.Include(q => q.LeaveType).ToListAsync();
            var model = new AdminLeaveRequestViewVM
            {
                TotalRequests = leaveRequests.Count,
                ApprovedRequests = leaveRequests.Count(q => q.Approved == true),
                PendingRequests = leaveRequests.Count(q => q.Approved == null),
                RejectedRequests = leaveRequests.Count(q => q.Approved == false),
                LeaveRequests = mapper.Map<List<LeaveRequestVM>>(leaveRequests)
            };

            //Agregamos los datos faltantes
            foreach (var leaveRequest in model.LeaveRequests)
            {
                leaveRequest.Employee = mapper.Map<EmployeeListVM>(await userManager.FindByIdAsync(leaveRequest.RequestingEmployeeId));
            }

            return model;
        }

        public async Task<List<LeaveRequestVM>> GetAllAsync(string employeeId)
        {
            return await context.LeaveRequests.Where(q => q.RequestingEmployeeId == employeeId)
                .ProjectTo<LeaveRequestVM>(configurationProvider)
                .ToListAsync();
        }

        public async Task<LeaveRequestVM?> GetLeaveRequestAsync(int? id)
        {
            //Primero se encuentra el leaverequest asociada con el id incluyendo los detalles del leavetype
            var leaveRequest = await context.LeaveRequests.Include(q => q.LeaveType).FirstOrDefaultAsync(q => q.Id == id);

            //Si no encuentra nada entonces que devuelva null
            if (leaveRequest == null)
            {
                return null;
            }

            //Mapeamos a la clase view model del leaverequest y el empleado (el empleado tambien va y lo busca antes de mapearlo)
            var model = mapper.Map<LeaveRequestVM>(leaveRequest);
            model.Employee = mapper.Map<EmployeeListVM>(await userManager.FindByIdAsync(leaveRequest?.RequestingEmployeeId));

            //Regresamos la consulta 
            return model;
        }

        public async Task<EmployeeLeaveRequestViewVM> GetMyLeaveDetails()
        {
            //Consultamos al usuario asociado con esta request y traemos sus datos
            var user = await userManager.GetUserAsync(httpContextAccessor?.HttpContext?.User);
            var allocations = (await leaveAllocationRepository.GetEmployeeAllocations(user.Id)).LeaveAllocations;
            var requests = await GetAllAsync(user.Id);

            //Crea el return model con el view vm
            var model = new EmployeeLeaveRequestViewVM(allocations, requests);
            return model;
        }
    }
}
