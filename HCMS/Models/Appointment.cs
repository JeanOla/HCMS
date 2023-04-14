using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Build.Framework;

namespace HCMS.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public string DoctorId { get; set; }
        [ValidateNever]
        public ApplicationUser User { get; set; }
        [Required]
        public DateTime appointmentDay { get; set; }
        [Required]
        public DateTime appointmentime { get; set; }
        [Required]
        public string Status { get;set; }
        [Required]
        public int caseId { get; set; }
        [ValidateNever]
        public Cases cases { get; set; }
    }
}
