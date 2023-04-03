using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace HCMS.Models
{
    public class MedicalRecord
    {
        public int Id { get; set; }
        public int patientId { get; set; }
        [ValidateNever]
        public Patient Patient { get; set; }
        public string? allergy { get; set; }
        public string? medication { get; set; }
        public string? bloodType { get; set; }
        public bool diabetic { get; set; }
        public string? surgery { get; set; }
        public string? vacinated { get; set; }


    }
}
