using LeaveManagement.Web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using LeaveManagement.Web.Configuration;
using LeaveManagement.Web.Contracts;
using LeaveManagement.Web.Repositories;
using Microsoft.AspNetCore.Identity.UI.Services;
using LeaveManagement.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//RequieredConfirmedAccount impide que una cuenta sin confirmar no pueda logearse en el sistema, ademas agrega roles
builder.Services.AddDefaultIdentity<Employee>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

//Permite el acceso al HttpContext desde clases que no sean controller
builder.Services.AddHttpContextAccessor();

//Implementacion el servicio de email de prueba Papercut-SMTP
builder.Services.AddTransient<IEmailSender>(s => new EmailSender("localhost", 25, "no-reply@leavemanagement.com"));

//Se registran nuestros repositorios y se permite que se puedan inyectar en nuestras clases sin necesidad de ILeaveTypeRepository y parecidos,
//pero al agregar tambien el repositorio se sabe exactamente que se esta inyectando
//(AddScoped da una nueva conexion, y una vez terminado con el se termina, significando que abre una conexion y la cierra cuando termina en lugar
//de manejarla de maneras diferentes como Transient o Singlenton)
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
builder.Services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();
builder.Services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();

//Permite agregar el automapper al builder para hacer legales los mapeos
builder.Services.AddAutoMapper(typeof(MapperConfig));

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
