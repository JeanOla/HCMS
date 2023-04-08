using HCMS.data;
using HCMS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;

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
           
           return _dbContext.users.Include(s=>s.speciality).Where(s=>s.speciality.SpecialityName != null).AsNoTracking().ToList();
        }
        public ApplicationUser DeleteDoctor(string Id)
        {
            var doctor = _dbContext.users.AsNoTracking().ToList().FirstOrDefault(d => d.Id == Id);
            _dbContext.Remove(doctor);
            _dbContext.SaveChanges();
            return doctor;

        }
    }
}
