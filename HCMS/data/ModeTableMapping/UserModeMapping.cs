using HCMS.Models;
using Microsoft.EntityFrameworkCore;

namespace HCMS.data.ModeTableMapping
{
    public static class UserModeMapping
    {
        public static void UserModel(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Appointment>()
               .HasOne(p => p.Patient)
               .WithMany(a => a.Appointments).WillCascadeOnDelete(false);
               .HasForeignKey(p => p.PatientId);


            modelBuilder.Entity<MedicalRecord>()
            .HasOne(p => p.Patient)
            .WithOne(a => a.medical)
            .HasForeignKey<MedicalRecord>(p => p.patientId);

            modelBuilder.Entity<Cases>()
            .HasOne(md => md.medicalRecord)
            .WithMany(c => c.cases)
            .HasForeignKey(md => md.medicalRecordId);

          modelBuilder.Entity<Appointment>()
            .HasOne(c => c.cases)
            .WithMany(a => a.Appointments)
            .HasForeignKey(c => c.caseId);
          
        }
    }
}
