using HCMS.data;
using HCMS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HCMS.Repository.mySQL
{
    public class DoctorRepository : IDoctorRepository
    {
        HCMSDbContext _dbContext;
        private RoleManager<IdentityRole> _roleManager { get; }
        public DoctorRepository(HCMSDbContext dbContext, RoleManager<IdentityRole> roleManager)
        {
            _dbContext = dbContext;
            _roleManager = roleManager;
        }
        public List<Speciality> populateSpeciality()
        {
         
            return _dbContext.specialities.ToList();
        }
        public List<ApplicationUser> getDoctors()
        {
            var role = _roleManager.Roles.ToList();
            //return _dbContext.Employees.Include(e => e.department).AsNoTracking().ToList();
            //dbContext.Appointments.Where(a => a.Status == "Pending").ToList();
           return _dbContext.users.Include(s=>s.speciality).Where(s=>s.speciality.SpecialityName != null).AsNoTracking().ToList();
        }
    }
}
