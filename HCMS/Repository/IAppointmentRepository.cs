using HCMS.Models;

namespace HCMS.Repository
{
    public interface IAppointmentRepository
    {
        List<Appointment> getAllAppointment();
        Appointment addAppointment(Appointment app);
        List<Cases> getAllCases();
        List<ApplicationUser> getAllDoctor();
    }
}
