﻿using HCMS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HCMS.data.ModeTableMapping
{
    public static class UserModeMapping
    {
        
        public static void UserModel(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Appointment>()
               .HasOne(p => p.User)
               .WithMany(a => a.appointments)
               .HasForeignKey(p => p.DoctorId);

            modelBuilder.Entity<MedicalRecord>()
             .HasOne(p => p.Patient)
             .WithOne(a => a.medical)
             .HasForeignKey<MedicalRecord>(p => p.patientId).OnDelete(DeleteBehavior.ClientCascade);

             modelBuilder.Entity<Cases>()
             .HasOne(p => p.patient)
             .WithMany(c => c.cases)
             .HasForeignKey(p => p.patientId);

            modelBuilder.Entity<Appointment>()
               .HasOne(c => c.cases)
               .WithMany(a => a.Appointments)
               .HasForeignKey(c => c.caseId);

            modelBuilder.Entity<Schedule>().HasOne(d => d.User)
                .WithMany(s => s.schedules).HasForeignKey(d => d.doctorId);
        }
        public static void SeedDafaultData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>().HasData(
               new Patient
               {
                   Id = 1,
                   firstName = "Lhener Jean",
                   middleName = "Rareza",
                   lastName = "Olaguer",
                   Email = "ljolaguer@email.com",
                   address = "Cabuyao, Laguna",
                   phone = "09504645926",
                   gender = "Male",
                   dob = DateTime.Now,
               }
               );
            modelBuilder.Entity<MedicalRecord>().HasData(
             new MedicalRecord
             {
                 Id = 1,
                 patientId = 1,
                 allergy = null,
                 medication = null,
                 bloodType = "A+",
                 diabetic = "Yes",
                 surgery = null,
                 vacinated = null,
             }

            );
            modelBuilder.Entity<Speciality>().HasData(
             new Speciality
             {
                 Id = 1,
                 SpecialityName = "Neurology"
             }
             );
        }
    }
}
