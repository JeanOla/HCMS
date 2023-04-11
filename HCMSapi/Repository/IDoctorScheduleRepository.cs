using HCMSapi.Models;


namespace HCMSapi.Repository
{
    public interface IDoctorScheduleRepository
    {
        List<ApplicationUser> getDoctors();

        Schedule addSchedule(Schedule sched);

        List<Schedule> ScheduleList();

        Schedule GetDoctorSchedById(int Id);

        Schedule updateSchedule(Schedule sched);

        Schedule DeleteSchedule(int Id);

        ////doctor user
        List<Schedule> DoctorScheduleList(string Id);
    }
}
