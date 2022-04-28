using LeaveManagement.Web.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagement.Web.Configuration.Entities
{
    public class RoleSeedConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        //Implementacion de la entidad heredada
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            //Agrega el identity role de Administrador y usuarios regulares
            builder.HasData(
                new IdentityRole
                { 
                    Id = "cac43a6e-f7bb-4448-baaf-ladd431ccbbf",
                    Name = Roles.Administrator, //"Administrator",
                    NormalizedName = Roles.Administrator.ToUpper() //"ADMINISTRATOR"
                },
                new IdentityRole
                {
                    Id = "cac43a7e-f7cb-4448-baaf-labb431eabbf",
                    Name = Roles.User, //"User",
                    NormalizedName = Roles.User.ToUpper() //"USER"
                }
            );
        }
    }
}