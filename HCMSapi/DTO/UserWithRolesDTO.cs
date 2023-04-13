using System.ComponentModel.DataAnnotations;

namespace HCMSapi.DTO
{
    public class UserWithRolesDTO
    {
        public string UserId { get; set; }
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
        //public string Roles { get; set; }
        public List<string> Roles { get; set; }
    }
}

