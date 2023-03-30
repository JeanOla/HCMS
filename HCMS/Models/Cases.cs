using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace HCMS.Models
{
    public class Cases
    {
        public int Id { get; set; }
        public int medicalRecordId { get; set; }
        [ValidateNever]
        public MedicalRecord medicalRecord { get; set; }
        public string diagnosis { get; set; }
        public string doctorId { get; set; }
        // need to connect ApplicationUser Id for database relationship
        public string? treatmentPlan { get; set; }
        public List<Appointment> Appointments { get; set; }


    }
}
