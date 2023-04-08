using HCMS.data;
using HCMS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HCMS.Repository.mySQL
{
    public class DoctorScheduleRepository : IDoctorScheduleRepository
    {
        HCMSDbContext _dbContext;
        private RoleManager<IdentityRole> _roleManager { get; }
        public DoctorScheduleRepository(HCMSDbContext dbContext, RoleManager<IdentityRole> roleManager)
        {
            _dbContext = dbContext;
            _roleManager = roleManager;
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
    }
}
