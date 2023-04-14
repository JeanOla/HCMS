using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMS.Models
{
    public class Patient
    {
        public int Id { get; set; }
        [Required]
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }
        public string middleName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string address { get; set; }
        [Required]

        public string phone { get; set; }
        [Required]
        public string gender { get; set; }

        public DateTime? dob { get; set; }
        public List<Cases> cases { get; set; }
        public MedicalRecord medical { get; set; }
        [NotMapped]

        public string FullName => $"{firstName} {lastName}";
        [NotMapped]
        public string Name => $"{firstName} {middleName} {lastName} ";
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
