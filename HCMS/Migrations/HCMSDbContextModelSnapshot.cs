﻿// <auto-generated />
using System;
using HCMS.data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HCMS.Migrations
{
    [DbContext(typeof(HCMSDbContext))]
    partial class HCMSDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HCMS.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("dob")
                        .HasColumnType("datetime2");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("medicalLicenseNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("middleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("specialityId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("specialityId");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "f0fbf9f0-eb17-4c87-9c76-9de5451f74ae",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "792ac2b5-ed3d-419b-9f70-ad5ae4a5f721",
                            Email = "adminjuan@gmail.com",
                            EmailConfirmed = false,
                            Gender = "Male",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMINJUAN@GMAIL.COM",
                            NormalizedUserName = "ADMINJUAN@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEBErig8XrSzdxcenmNR34WidXQ3R0QjmKJsgh/Ck5eGr9NfFedf7XRS3pWCxyUiINA==",
                            PhoneNumber = "09191231231",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "2979b7b1-a38a-4ab8-8da6-832a57ac2eb3",
                            TwoFactorEnabled = false,
                            UserName = "adminjuan@gmail.com",
                            address = "Sta. Rosa, Laguna",
                            dob = new DateTime(2023, 5, 18, 9, 53, 29, 393, DateTimeKind.Local).AddTicks(9246),
                            firstName = "Juan",
                            lastName = "Cruz",
                            middleName = "Dela"
                        });
                });

            modelBuilder.Entity("HCMS.Models.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("DoctorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("appointmentDay")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("appointmentime")
                        .HasColumnType("datetime2");

                    b.Property<int>("caseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("caseId");

                    b.ToTable("appointments");
                });

            modelBuilder.Entity("HCMS.Models.Cases", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("diagnosis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("patientId")
                        .HasColumnType("int");

                    b.Property<string>("reason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("treatmentPlan")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("patientId");

                    b.ToTable("cases");
                });

            modelBuilder.Entity("HCMS.Models.MedicalRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("allergy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("bloodType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("diabetic")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("medication")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("patientId")
                        .HasColumnType("int");

                    b.Property<string>("surgery")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("vacinated")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("patientId")
                        .IsUnique();

                    b.ToTable("medicalRecords");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            bloodType = "A+",
                            diabetic = "Yes",
                            patientId = 1
                        });
                });

            modelBuilder.Entity("HCMS.Models.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("dob")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("middleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("patients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "ljolaguer@email.com",
                            address = "Cabuyao, Laguna",
                            dob = new DateTime(2023, 5, 18, 9, 53, 29, 397, DateTimeKind.Local).AddTicks(6644),
                            firstName = "Lhener Jean",
                            gender = "Male",
                            lastName = "Olaguer",
                            middleName = "Rareza",
                            phone = "09504645926"
                        });
                });

            modelBuilder.Entity("HCMS.Models.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("dayOfWeek")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("doctorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("endTime")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("startTime")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("doctorId");

                    b.ToTable("schedules");
                });

            modelBuilder.Entity("HCMS.Models.Speciality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("SpecialityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("specialities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            SpecialityName = "Neurology"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "fb63abec-98f5-448e-8f56-302fafd16df4",
                            ConcurrencyStamp = "194a4fb5-0419-4ee5-b610-139ede17aee7",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "5c965850-234a-4d90-9c24-024ebfac6f20",
                            ConcurrencyStamp = "c7adcfa0-bdf3-4b54-9788-e5710b3d7326",
                            Name = "Doctor",
                            NormalizedName = "DOCTOR"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "f0fbf9f0-eb17-4c87-9c76-9de5451f74ae",
                            RoleId = "fb63abec-98f5-448e-8f56-302fafd16df4"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("HCMS.Models.ApplicationUser", b =>
                {
                    b.HasOne("HCMS.Models.Speciality", "speciality")
                        .WithMany("applicationUsers")
                        .HasForeignKey("specialityId");

                    b.Navigation("speciality");
                });

            modelBuilder.Entity("HCMS.Models.Appointment", b =>
                {
                    b.HasOne("HCMS.Models.ApplicationUser", "User")
                        .WithMany("appointments")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HCMS.Models.Cases", "cases")
                        .WithMany("Appointments")
                        .HasForeignKey("caseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("cases");
                });

            modelBuilder.Entity("HCMS.Models.Cases", b =>
                {
                    b.HasOne("HCMS.Models.Patient", "patient")
                        .WithMany("cases")
                        .HasForeignKey("patientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("patient");
                });

            modelBuilder.Entity("HCMS.Models.MedicalRecord", b =>
                {
                    b.HasOne("HCMS.Models.Patient", "Patient")
                        .WithOne("medical")
                        .HasForeignKey("HCMS.Models.MedicalRecord", "patientId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("HCMS.Models.Schedule", b =>
                {
                    b.HasOne("HCMS.Models.ApplicationUser", "User")
                        .WithMany("schedules")
                        .HasForeignKey("doctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("HCMS.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("HCMS.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HCMS.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("HCMS.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HCMS.Models.ApplicationUser", b =>
                {
                    b.Navigation("appointments");

                    b.Navigation("schedules");
                });

            modelBuilder.Entity("HCMS.Models.Cases", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("HCMS.Models.Patient", b =>
                {
                    b.Navigation("cases");

                    b.Navigation("medical")
                        .IsRequired();
                });

            modelBuilder.Entity("HCMS.Models.Speciality", b =>
                {
                    b.Navigation("applicationUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
