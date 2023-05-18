using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace HCMSapi.DTO
{
    public class UpdateCasaeDTO
    {
     
        public int patientId { get; set; }
        [ValidateNever]
        public string? diagnosis { get; set; }
        public string? treatmentPlan { get; set; }
        [Required]
        public string reason { get; set; }
    }
}
