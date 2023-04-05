using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMS.Models
{
    public class Cases
    {
        public int Id { get; set; }
        public int patientId { get; set; }
        [ValidateNever]
        public Patient patient { get; set; }
        public string? diagnosis { get; set; }
        public string? treatmentPlan { get; set; }
        public string reason { get; set; }

        public List<Appointment> Appointments { get; set; }
        [NotMapped]
        [ValidateNever]
        public string fullcase => $"{Id} {patient.firstName} {patient.lastName} {reason}";

    }
}
