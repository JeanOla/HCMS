using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace HCMS.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public DateTime? dob { get; set; }
        public string address { get; set; }
         public string? medicalLicenseNumber { get; set; }
        public int? specialityId { get; set; }
        [ValidateNever]
        public Speciality speciality { get; set; }
        public string Gender { get; set; }
        public List<Schedule> schedules { get; set; }
        [NotMapped]
        public string FullName => $"{firstName} {lastName}";
        public List<Appointment> appointments { get; set; }
        public string FullNameWithMiddle => $"{firstName} {middleName} {lastName}";
    }
}
