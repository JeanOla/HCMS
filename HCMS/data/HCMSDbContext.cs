using HCMS.data.ModeTableMapping;
using HCMS.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HCMS.data
{
    public class HCMSDbContext : IdentityDbContext<ApplicationUser>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=HMSDB;Integrated Security=True;";
            optionsBuilder.UseSqlServer(connectionString)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.UserModel();
            base.OnModelCreating(builder);
        }
       public DbSet<Appointment> appointments { get; set; }
        public DbSet<Cases> cases { get; set; }
        public DbSet<MedicalRecord> medicalRecords { get; set; }
        public DbSet<Patient> patients { get; set; }
        public DbSet<Schedule> schedules { get; set; }
        public DbSet<Speciality> specialities { get; set; }
    }
}
