using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HCMS.Models
{
    public class Schedule
    {
        public int Id { get; set; } 
        public string doctorId { get; set; }
        //build relationship wit hdoctor
        public ApplicationUser User { get; set; }
        public string dayOfWeek { get; set; }
        [BindProperty, DataType(DataType.Time)]
        public DateTime? startTime { get; set; }
        [BindProperty, DataType(DataType.Time)]
        public DateTime? endTime { get; set; }
    }
}
