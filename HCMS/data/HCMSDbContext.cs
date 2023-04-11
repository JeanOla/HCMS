using HCMS.data.ModeTableMapping;
using HCMS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HCMS.data
{
    public class HCMSDbContext : IdentityDbContext<ApplicationUser>
    {
        public IConfiguration _appConfig { get; }
        public ILogger _logger { get; }
        public IWebHostEnvironment _env { get; }

        public HCMSDbContext(IConfiguration appConfig, ILogger<HCMSDbContext> logger, IWebHostEnvironment env)
        {
            _appConfig = appConfig;
            _logger = logger;
            _env = env;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            var server = _appConfig.GetConnectionString("Server");
            var db = _appConfig.GetConnectionString("DB");


            string connectionString;
            if (_env.IsDevelopment())
            {
                 connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=HMSDB;Integrated Security=True;";
                //connectionString = $"Server={server};Database={db};MultipleActiveResultSets=true;Integrated Security=false;TrustServerCertificate=true";
            }
            else
            {
                var userName = _appConfig.GetConnectionString("UserName");
                var password = _appConfig.GetConnectionString("Password");
                connectionString = $"Server={server};Database={db};User Id={userName};Password={password};MultipleActiveResultSets=true;Integrated Security=false;TrustServerCertificate=true";
            }
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException("Connection string is not configured");
            }

            //_logger.LogInformation("Db Connection string: " + connectionString);
            //string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=HMSDB;Integrated Security=True;";
            optionsBuilder.UseSqlServer(connectionString)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.UserModel();
            builder.SeedDafaultData();
            base.OnModelCreating(builder);
        }
       public DbSet<Appointment> appointments { get; set; }
        public DbSet<Cases> cases { get; set; }
        public DbSet<MedicalRecord> medicalRecords { get; set; }
        public DbSet<Patient> patients { get; set; }
        public DbSet<Schedule> schedules { get; set; }
        public DbSet<Speciality> specialities { get; set; }
        public DbSet<IdentityRole> Roles { get; set; }

     
        public DbSet<ApplicationUser> users { get; set; }
       
    }
}
