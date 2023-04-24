using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMS.Models
{
    public class Patient
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z.'\\s]+$", ErrorMessage = "Only letters, periods, and apostrophes are allowed.")]
        [DisplayName("First Name")]
        public string firstName { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z.'\\s]+$", ErrorMessage = "Only letters, periods, and apostrophes are allowed.")]
        [DisplayName("Last Name")]
        public string lastName { get; set; }
        [RegularExpression("^[a-zA-Z.'\\s]+$", ErrorMessage = "Only letters, periods, and apostrophes are allowed.")]
        [DisplayName("Middle Name")]
        public string middleName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string address { get; set; }
        [Required]
        [RegularExpression(@"^(\+?\d{1,2}\s)?\(?\d{3}\)?[-.\s]?\d{3,11}$", ErrorMessage = "Invalid phone number.")]
        [DisplayName("Contact Number")]
        public string phone { get; set; }
        [Required]
        public string gender { get; set; }
        [Required]
        [DisplayName("Date of birth")]
        public DateTime? dob { get; set; }
        [ValidateNever]
        public List<Cases> cases { get; set; }
        [ValidateNever]
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
