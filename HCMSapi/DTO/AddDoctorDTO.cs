using HCMSapi.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace HCMSapi.DTO
{
    public class AddDoctorDTO
    {
            [Required]
            public string firstName { get; set; }
            [Required]
            public string middleName { get; set; }
            [Required]
            public string lastName { get; set; }
            [Required]
            public DateTime? dob { get; set; }
            [Required]
            public string address { get; set; }
            [Required]
            [EmailAddress]
            public string Email { get; set; }
            [Required]
            public int specialityId { get; set; }
            [Required]
            public string gender { get; set; }
            [Required]
            public string PhoneNumber { get; set; }
            [Required]
            [DataType(DataType.Password)]
            public string password { get; set; }
            [Required]
            [Compare("password", ErrorMessage = "The COnfirm Password Does not matched to the password")]
            public string confirmPassword { get; set; }

        
    }
}
