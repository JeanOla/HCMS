using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace HCMS.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        [ValidateNever]
        public ApplicationUser User { get; set; }
        public int PatientId { get; set; }
        [ValidateNever]
        public Patient Patient { get; set; }    
        public DateTime appoinmentDate { get; set; }
        public string Status { get;set; }
        public int caseId { get; set; }
        [ValidateNever]
        public Cases cases { get; set; }
    }
}
