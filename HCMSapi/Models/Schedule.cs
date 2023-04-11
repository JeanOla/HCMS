using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HCMSapi.Models
{
    public class Schedule
    {
        public int Id { get; set; } 
        public string doctorId { get; set; }
        public ApplicationUser User { get; set; }
        [Required]
        public string dayOfWeek { get; set; }
        [BindProperty, DataType(DataType.Time)]
        [Required]
        public DateTime? startTime { get; set; }
        [BindProperty, DataType(DataType.Time)]
        [Required]
        public DateTime? endTime { get; set; }
    }
}
