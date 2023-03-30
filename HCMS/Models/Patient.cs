namespace HCMS.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string middleName { get; set; }
        public string Email { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string gender { get; set; }

        public List<Appointment> Appointments { get; set; }

        public MedicalRecord medical { get; set; }
    }
}
