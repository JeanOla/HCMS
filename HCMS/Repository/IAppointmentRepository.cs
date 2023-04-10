using HCMS.Models;

namespace HCMS.Repository
{
    public interface IAppointmentRepository
    {
        List<Appointment> getAllAppointment();
        Appointment addAppointment(Appointment app);
        List<Cases> getAllCases();
        List<ApplicationUser> getAllDoctor();

        Appointment GetAppointmentById(int id);

        Appointment updateAppointment(Appointment app);
        Appointment DeleteAppointment(int Id);

        List<Schedule> getAllDoctorByDay(string newDay);
        List<Appointment> getAllDoctorAppointment(string Id);
    }
}
