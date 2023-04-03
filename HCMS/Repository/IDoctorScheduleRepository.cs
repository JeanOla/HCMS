using HCMS.Models;
using HCMS.ViewModel;

namespace HCMS.Repository
{
    public interface IDoctorScheduleRepository
    {
        List<ApplicationUser> getDoctors();

        Schedule addSchedule(Schedule sched);

        List<Schedule> ScheduleList();
       
    }
}
