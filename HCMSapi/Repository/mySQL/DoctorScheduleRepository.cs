using HCMSapi.data;
using HCMSapi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HCMSapi.Repository.mySQL
{
    public class DoctorScheduleRepository : IDoctorScheduleRepository
    {
        HCMSDbContext _dbContext;
        private RoleManager<IdentityRole> _roleManager { get; }
        public UserManager<ApplicationUser> _userManager { get; }

        public DoctorScheduleRepository(HCMSDbContext dbContext, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public List<ApplicationUser> getDoctors()
        {
            return _dbContext.users.Include(s => s.speciality).Where( s => s.speciality.SpecialityName != null).AsNoTracking().ToList();
        }
        public List<Schedule> ScheduleList()
        {
            return _dbContext.schedules.Include(s => s.User).AsNoTracking().ToList();
        }
        public Schedule addSchedule(Schedule sched)
        {
            _dbContext.Add(sched);
            _dbContext.SaveChanges();
            return sched;
        }
        public Schedule GetDoctorSchedById(int Id)
        {
            return _dbContext.schedules.Include(s => s.User).AsNoTracking().ToList().FirstOrDefault(doc => doc.Id == Id);

        }
        public Schedule updateSchedule(Schedule sched)
        {
            _dbContext.schedules.Attach(sched);
            _dbContext.Update(sched);
            _dbContext.SaveChanges();
            return sched;
        }

        public Schedule DeleteSchedule(int Id)
        {
            var sched = GetDoctorSchedById(Id);
            _dbContext.Remove(sched);
            _dbContext.SaveChanges();
            return sched;
        }
        ///////////////////////////////////////////////////
        /////for doctor
        public List<Schedule> DoctorScheduleList(string Id)
        {
            
            return _dbContext.schedules.Include(s => s.User).Where(d => d.doctorId == Id).AsNoTracking().ToList();
        }
    }
}
