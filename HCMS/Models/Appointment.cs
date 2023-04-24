using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Build.Framework;
using System.ComponentModel;

namespace HCMS.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        [Required]
        [DisplayName("Doctor")]
        public string DoctorId { get; set; }//owner
        [ValidateNever]
        public ApplicationUser User { get; set; }
        [Required]
        [DisplayName("Appointment Day")]
        public DateTime appointmentDay { get; set; }
        [Required]
        [DisplayName("Appointment Time")]
        public DateTime appointmentime { get; set; }
        [Required]
        public string Status { get;set; }
        [Required]
        public int caseId { get; set; }
        [ValidateNever]
        public Cases cases { get; set; }
    }
}
