using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCMS.ViewModel
{
    public class addCaseViewModel
    {
        public int patientId { get; set; }
        [ValidateNever]
        public string? diagnosis { get; set; }
        public string? treatmentPlan { get; set; }
        [Required]
        public string reason { get; set; }
        public string rawcase => $" Patient Id: {patientId} - Reason: {reason}";
    }
}
