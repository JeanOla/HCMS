using HCMS.data;
using HCMS.Models;
using HCMS.Repository;
using HCMS.Repository.mySQL;
using Microsoft.AspNetCore.DataProtection.Repositories;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//api 
builder.Services.AddSession();


builder.Services.AddDbContext<HCMSDbContext>();
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<HCMSDbContext>();

builder.Services.AddScoped<HCMSDbContext, HCMSDbContext>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IadminRepository, AdminRepository>();
builder.Services.AddScoped<IDoctorScheduleRepository, DoctorScheduleRepository>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<ICaseRepository, CaseRepository>();
builder.Services.AddScoped<IspecialityRepository, SpecialityRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

//api
app.UseHttpsRedirection();

app.UseStaticFiles();
app.Automigrate();
app.UseRouting();

//app.UseAuthorization();
app.UseAuthentication();
app.UseAuthorization();
//api
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=login}/{id?}");
app.Run();
