﻿using LeaveManagement.Web.Configuration.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LeaveManagement.Web.Models;

namespace LeaveManagement.Web.Data
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

        public DbSet<LeaveType> LeaveTypes { get; set; }

        public DbSet<LeaveAllocation> LeaveAllocations { get; set; }

        //public DbSet<LeaveManagement.Web.Models.LeaveAllocationEditVM>? LeaveAllocationEditVM { get; set; }

        //public DbSet<LeaveManagement.Web.Models.EmployeeAllocationVM>? EmployeeAllocationVM { get; set; }

        //Aqui se creo este objeto debido a que se creo con scafold la vista de EmployeesController,
        //pero debido a que no queremos una nueva tabla con este nombre simplemente comentamos este codigo generado
        //public DbSet<LeaveManagement.Web.Models.EmployeeListVM> EmployeeListVM { get; set; }
    }
}