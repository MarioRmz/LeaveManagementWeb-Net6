using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagement.Web.Configuration.Entities
{
    public class UserRoleSeedConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        //Implementacion de la entidad heredada
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            //Agrega la relacion entre usuarios y roles
            builder.HasData(
                //Admin
                new IdentityUserRole<string>
                { 
                    RoleId = "cac43a6e-f7bb-4448-baaf-ladd431ccbbf",
                    UserId = "408qq945-3d84-4421-8342-7269ec64d949"
                },
                //User
                new IdentityUserRole<string>
                {
                    RoleId = "cac43a7e-f7cb-4448-baaf-labb431eabbf",
                    UserId = "30fq19bd-f907-4409-b416-ba356312e659"
                }
            );
        }
    }
}