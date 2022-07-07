using LeaveManagement.Data.Configuration.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Data
{
    //public class ApplicationDbContext : IdentityDbContext
    //Usa Employee para hacer la tabla de usuarios asp
    public class ApplicationDbContext : IdentityDbContext<Employee>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //Cuando se genera la db se desencadena lo siguiente de manera adicional
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RoleSeedConfiguration());
            builder.ApplyConfiguration(new UserSeedConfiguration());
            builder.ApplyConfiguration(new UserRoleSeedConfiguration());
        }

        //Sobreescribimos el SaveChangesAsync utilizado por toda la aplicacion
        //con el fin de setear los datos DateModofied y DateCreated en un solo lugar
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //Cicla las entidades que fueron recien agregadas o modificadas
            foreach (var entry in base.ChangeTracker.Entries<BaseEntity>().Where(q => q.State == EntityState.Added || 
                q.State == EntityState.Modified))
            {
                //Fecha de modificacion es siempre now porque se esta haciendo cambios en el momento
                entry.Entity.DateModified = DateTime.Now;

                //Si la entidad es nueva entonces se le agrega el date created como now tambien
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.DateCreated = DateTime.Now;
                }
            }

            //Devuelve para salvar cambios
            return base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<LeaveType> LeaveTypes { get; set; }

        public DbSet<LeaveAllocation> LeaveAllocations { get; set; }

        public DbSet<LeaveRequest> LeaveRequests { get; set; }

        //public DbSet<LeaveManagement.Web.Models.LeaveAllocationEditVM>? LeaveAllocationEditVM { get; set; }

        //public DbSet<LeaveManagement.Web.Models.EmployeeAllocationVM>? EmployeeAllocationVM { get; set; }

        //Aqui se creo este objeto debido a que se creo con scafold la vista de EmployeesController,
        //pero debido a que no queremos una nueva tabla con este nombre simplemente comentamos este codigo generado
        //public DbSet<LeaveManagement.Web.Models.EmployeeListVM> EmployeeListVM { get; set; }
    }
}