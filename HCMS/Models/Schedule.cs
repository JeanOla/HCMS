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
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime? startTime { get; set; }
        [DataType(DataType.Time)] // Only store time in the database
        [DisplayFormat(DataFormatString = "{0:hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime? endTime { get; set; }
    }
}
