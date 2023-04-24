using HCMS.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace HCMS.ViewModel
{
    public class RegisterAdminViewModel
    {
        [Required]
        [RegularExpression("^[a-zA-Z.'\\s]+$", ErrorMessage = "Only letters, periods, and apostrophes are allowed.")]
        [DisplayName("First Name")]
        public string firstName { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z.'\\s]+$", ErrorMessage = "Only letters, periods, and apostrophes are allowed.")]
        [DisplayName("Middle Name")]
        public string middleName { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z.'\\s]+$", ErrorMessage = "Only letters, periods, and apostrophes are allowed.")]
        [DisplayName("Last Name")]
        public string lastName { get; set; }
        [Required]
        [DisplayName("Date of Birth")]
        public DateTime? dob { get; set; }
        [Required]
        public string address { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string gender { get; set; }
        [Required]
        [RegularExpression(@"^(\+?\d{1,2}\s)?\(?\d{3}\)?[-.\s]?\d{3,11}$", ErrorMessage = "Invalid phone number.")]
        [DisplayName("Contact Number")]
        public string PhoneNumber { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{6,}$",
        ErrorMessage = "Password must be at least 6 characters long and contain at least one uppercase letter, one lowercase letter, one digit, and one special character.")]
        public string password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("password", ErrorMessage = "The COnfirm Password Does not matched to the password")]
        public string confirmPassword { get; set; }

        public string FullNameWithMiddle => $"{firstName} {middleName} {lastName}";
    }
}
