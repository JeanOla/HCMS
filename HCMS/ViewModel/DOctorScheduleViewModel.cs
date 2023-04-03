using HCMS.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace HCMS.ViewModel
{
    public class DOctorScheduleViewModel
    {
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public int? specialityId { get; set; }
        [ValidateNever]
        public Speciality speciality { get; set; }

        public int Id { get; set; }
        public string doctorId { get; set; }
        //build relationship wit hdoctor
        public ApplicationUser User { get; set; }
        public string dayOfWeek { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? startTime { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? endTime { get; set; }
    }
}
