using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace HCMS.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public string? DoctorId { get; set; }
        [ValidateNever]
        public ApplicationUser User { get; set; }    
        public string appointmentDay { get; set; }

        public DateTime appointmentime { get; set; }
        public string Status { get;set; }
        public int caseId { get; set; }
        [ValidateNever]
        public Cases cases { get; set; }
    }
}
