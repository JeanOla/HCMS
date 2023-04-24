using HCMSapi.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace HCMSapi.DTO
{
    public class AddDoctorDTO
    {
        [Required]
        [RegularExpression("^[a-zA-Z.'\\s]+$", ErrorMessage = "Only letters, periods, and apostrophes are allowed.")]
        public string firstName { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z.'\\s]+$", ErrorMessage = "Only letters, periods, and apostrophes are allowed.")]
        public string middleName { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z.'\\s]+$", ErrorMessage = "Only letters, periods, and apostrophes are allowed.")]
        public string lastName { get; set; }
        [Required]
        [DisplayName("Date of Birth")]
        public DateTime? dob { get; set; }
        [Required]
        public string address { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string? medicalLicenseNumber { get; set; }

        public int? specialityId { get; set; }
        [Required]
        public string gender { get; set; }
        [RegularExpression(@"^(\+?\d{1,2}\s)?\(?\d{3}\)?[-.\s]?\d{3,11}$", ErrorMessage = "Invalid phone number.")]
        [DisplayName("Contact Number")]
        public string PhoneNumber { get; set; }
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{6,}$",
         ErrorMessage = "Password must be at least 6 characters long and contain at least one uppercase letter, one lowercase letter, one digit, and one special character.")]
        public string password { get; set; }
        [Required]
        [Compare("password", ErrorMessage = "The COnfirm Password Does not matched to the password")]
        public string confirmPassword { get; set; }


    }
}
