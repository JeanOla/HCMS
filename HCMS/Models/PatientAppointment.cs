namespace HCMS.Models
{
    public class PatientAppointment
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }
        public int AppointmentId { get; set; }
        public  Appointment Appointment { get; set; }
    }
}
