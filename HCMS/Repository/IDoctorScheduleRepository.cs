using HCMS.Models;
using HCMS.ViewModel;

namespace HCMS.Repository
{
    public interface IDoctorScheduleRepository
    {
        List<ApplicationUser> getDoctors();

        Schedule addSchedule(Schedule sched);

        List<Schedule> ScheduleList();

        Schedule GetDoctorSchedById(int Id);

        Schedule updateSchedule(Schedule sched);
    }
}
