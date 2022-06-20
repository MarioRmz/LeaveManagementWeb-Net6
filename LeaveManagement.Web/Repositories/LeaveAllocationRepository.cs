using AutoMapper;
using LeaveManagement.Web.Constants;
using LeaveManagement.Web.Contracts;
using LeaveManagement.Web.Data;
using LeaveManagement.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Web.Repositories
{
    //Implementacion
    //Esto va a ser relativo a LeaveAllocation y al mismo tiempo heredara de ILeaveAllocationRepository

    //NOTA: Comparado a LeaveTypeRepository y ILeaveTypeRepository, aqui y en ILeaveAllocationRepository se tienen Tasks extras
    //porque se necesitan procesos especificos que no se tienen en el GenericRepository, por lo mismo estos objetos 
    //contienen Tasks que los otros no
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        //Se inyecta el user manager relativo a Employee y el leavetyperepository
        //Esto con el fin de seguir el orden de datos y no utilizar el context sin hacer uso de una clase generica
        //Sin embargo para poder hacer el chequeo de si Allocation existe, se necesita si o si el context, por lo que se va a 
        //hacer una excepcion en este caso
        private readonly ApplicationDbContext context;           
        private readonly UserManager<Employee> userManager;
        private readonly ILeaveTypeRepository leaveTypeRepository;
        private readonly IMapper mapper;
        public LeaveAllocationRepository(ApplicationDbContext context, 
            UserManager<Employee> userManager, ILeaveTypeRepository leaveTypeRepository, IMapper mapper) : base(context)
        {
            this.context = context;
            this.userManager = userManager;
            this.leaveTypeRepository = leaveTypeRepository;
            this.mapper = mapper;
        }

        public async Task<bool> AllocationExists(string employeeId, int leaveTypeId, int period)
        {
            return await context.LeaveAllocations.AnyAsync(q => q.EmployeeId == employeeId
            && q.LeaveTypeId == leaveTypeId
            && q.Period == period);
        }

        public async Task<EmployeeAllocationVM> GetEmployeeAllocations(string employeeId)
        {
            //Trae todos las allocations donde el id del empleado corresponda y traiga tambien los leave type
            //Equivale a un inner join para traer los leave type
            var allocations = await context.LeaveAllocations
                .Include(q => q.LeaveType)
                .Where(q => q.EmployeeId == employeeId).ToListAsync();

            var employee = await userManager.FindByIdAsync(employeeId);

            //Mapeamos los resultados para que la info del empleado se acomode a EmployeeAllocationVM y este contenga un listado de LeaveAllocationVM
            var employeeAllocationModel = mapper.Map<EmployeeAllocationVM>(employee);
            employeeAllocationModel.LeaveAllocations = mapper.Map<List<LeaveAllocationVM>>(allocations);

            return employeeAllocationModel;
        }

        public async Task<LeaveAllocationEditVM> GetEmployeeAllocation(int id)
        {
            //Trae la allocation donde el id corresponda y traiga tambien los leave type
            //Equivale a un inner join para traer los leave type
            var allocation = await context.LeaveAllocations
                .Include(q => q.LeaveType)
                .FirstOrDefaultAsync(q => q.Id == id);

            if (allocation == null)
            {
                return null;
            }

            var employee = await userManager.FindByIdAsync(allocation.EmployeeId);

            //Mapeamos los resultados para que la info de la allocation se acomode a LeaveAllocationEditVM y este contenga un EmployeeListVM correspondiente
            var model = mapper.Map<LeaveAllocationEditVM>(allocation);
            model.Employee = mapper.Map<EmployeeListVM>(await userManager.FindByIdAsync(allocation.EmployeeId));

            return model;
        }

        public async Task LeaveAllocation(int leaveTypeId)
        {
            //Los unicos que necesitan asignaciones (allocations) son los usuarios, por eso se traen solamente a los Users
            var employees = await userManager.GetUsersInRoleAsync(Roles.User);
            var period = DateTime.Now.Year;
            var leaveType = await leaveTypeRepository.GetAsync(leaveTypeId);
            var allocations = new List<LeaveAllocation>();

            //Si bien esto funciona, provocara que AddAsync ejecute multiples veces un commit en el context,
            //por lo que esto va a sustituirse por algo mas practico donde solo se haga un commit
            //foreach (var employee in employees)
            //{
            //    var allocation = new LeaveAllocation
            //    {
            //        EmployeeId = employee.Id,
            //        LeaveTypeId = leaveTypeId,
            //        Period = period,
            //        NumberOfDays = leaveType.DefaultDays //Se inyecto ILeaveTypeRepository para poder obtener este campo sin abusar de context
            //    };

            //    //Agrega el nuevo LeaveAllocation al context
            //    await AddAsync(allocation);
            //}

            foreach (var employee in employees)
            {
                //Antes de agregar employee al listado revisa si ya existe en el contexto
                if (await AllocationExists(employee.Id, leaveTypeId, period))
                    continue; //<-- continue se salta el resto de este ciclo y se va a la siguiente corrida

                allocations.Add(new LeaveAllocation
                {
                    EmployeeId = employee.Id,
                    LeaveTypeId = leaveTypeId,
                    Period = period,
                    NumberOfDays = leaveType.DefaultDays //Se inyecto ILeaveTypeRepository para poder obtener este campo sin abusar de context
                });               
            }

            //Agrega el nuevo LeaveAllocation al context
            await AddRangeAsync(allocations);
        }

        public async Task<bool> UpdateEmployeeAllocation(LeaveAllocationEditVM model)
        {
            //Se busca el leaveAllocation necesario
            var leaveAllocation = await GetAsync(model.Id);
            if (leaveAllocation == null)
            {
                return false;
            }

            //Ya que lo trajo se editan los campos y se actualiza la entidad
            leaveAllocation.Period = model.Period;
            leaveAllocation.NumberOfDays = model.NumberOfDays;
            await UpdateAsync(leaveAllocation);
            return true;
        }

        public async Task<LeaveAllocation?> GetEmployeeAllocation(string employeeId, int leaveTypeId)
        {
            //Devuelve el LeaveAllocation correspondiente
            return await context.LeaveAllocations.FirstOrDefaultAsync(q => q.EmployeeId == employeeId && q.LeaveTypeId == leaveTypeId);
        }
    }
}
