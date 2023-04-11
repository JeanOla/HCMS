using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace HCMSapi.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public string DoctorId { get; set; }
        [ValidateNever]
        public ApplicationUser User { get; set; }
        [Required]
        public string appointmentDay { get; set; }
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
