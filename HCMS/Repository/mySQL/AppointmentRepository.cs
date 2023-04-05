using HCMS.data;
using HCMS.Models;
using Microsoft.EntityFrameworkCore;

namespace HCMS.Repository.mySQL
{
    public class AppointmentRepository : IAppointmentRepository
    {
        HCMSDbContext _dbContext;


        public AppointmentRepository(HCMSDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Appointment> getAllAppointment()
        {
           
            return _dbContext.appointments.Include(a => a.cases.patient).Include(a => a.User).AsNoTracking().ToList();
        }

        public List<Cases> getAllCases()
        {
            return _dbContext.cases.Include(p => p.patient).AsNoTracking().ToList();
        }
        public List<ApplicationUser> getAllDoctor()
        {
           return _dbContext.users.Include(s => s.speciality).Where(s => s.speciality.SpecialityName != null).AsNoTracking().ToList();
        }
        public Appointment addAppointment(Appointment app)
        {
            _dbContext.Add(app);
            _dbContext.SaveChanges();
            return app;
        }
    }
}
