using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HCMSapi.DTO
{
    public class AddDoctorScheduleDTO
    {
        public string doctorId { get; set; }

        public string dayOfWeek { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh:mm tt}")]
        [Required]
        public DateTime? startTime { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:hh:mm tt}")]
        [Required]
        public DateTime? endTime { get; set; }
    }
}
