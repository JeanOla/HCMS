using System.ComponentModel.DataAnnotations.Schema;

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

        public DateTime? dob { get; set; }
        public List<Cases> cases { get; set; }
        public MedicalRecord medical { get; set; }
        [NotMapped]

        public string FullName => $"{firstName} {lastName}";
        public Patient()
        {

        }
        public Patient(int id, string firstName, string lastName, string middleName, string email, string address, string phone, string gender, List<Appointment> appointments, MedicalRecord medical)
        {
            Id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.middleName = middleName;
            Email = email;
            this.address = address;
            this.phone = phone;
            this.gender = gender;
            medical = medical;
        }
    }
}
