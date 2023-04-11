using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMSapi.Models
{
    public class Cases
    {
        public int Id { get; set; }
        [Required]
        public int patientId { get; set; }
        [ValidateNever]
        public Patient patient { get; set; }
        public string? diagnosis { get; set; }
        public string? treatmentPlan { get; set; }
        [Required]
        public string reason { get; set; }

        public List<Appointment> Appointments { get; set; }
        [NotMapped]
        [ValidateNever]
        public string fullcase => $" Patient Name: {patient.firstName} {patient.lastName} - Reason: {reason}";

    }
}
