using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace HCMS.ViewModel
{
    public class ChangePasswordViewModel
    {
        public string Id { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string CurrentPassword { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("password", ErrorMessage = "The Confirm Password Does not matched to the password")]
        public string confirmPassword { get; set; }
    }
}
