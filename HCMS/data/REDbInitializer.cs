using HCMS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HCMS.data
{
    public static class REDbInitializer
    {
        public static void RolesSeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
           new IdentityRole
           {
               Id = "fb63abec-98f5-448e-8f56-302fafd16df4",
               Name = "Admin",
               NormalizedName = "ADMIN",
           },
            new IdentityRole
            {
                Id = "5c965850-234a-4d90-9c24-024ebfac6f20",
                Name = "Doctor",
                NormalizedName = "DOCTOR",
            }
            );
        }
        public static void UserSeed(this ModelBuilder modelBuilder)
        {
            string defaultPassword = "09191234567Qwe!";

            var passwordHasher = new PasswordHasher<ApplicationUser>();
            modelBuilder.Entity<ApplicationUser>().HasData(
          new ApplicationUser
          {
              Id = "f0fbf9f0-eb17-4c87-9c76-9de5451f74ae",
              firstName = "Juan",
              middleName = "Dela",
              lastName = "Cruz",
              dob = null,
              address = "Sta. Rosa, Laguna",
              specialityId = null,
              Gender = "Male",
              UserName = "adminjuan@gmail.com",
              NormalizedUserName = "adminjuan@gmail.com".ToUpper(),
              NormalizedEmail = "adminjuan@gmail.com".ToUpper(),
              Email = "adminjuan@gmail.com",
              PhoneNumber = "09191231231",
              PasswordHash = passwordHasher.HashPassword(null, defaultPassword)
          }
           );
        }
        public static void UserRoleSeed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "fb63abec-98f5-448e-8f56-302fafd16df4",
                    UserId = "f0fbf9f0-eb17-4c87-9c76-9de5451f74ae"
                }
            );
        }
    }
}
