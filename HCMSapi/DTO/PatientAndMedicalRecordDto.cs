using System.ComponentModel.DataAnnotations;

namespace HCMSapi.DTO
{
    public class PatientAndMedicalRecordDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
        [Required]
        public string Gender { get; set; }
        public DateTime? Dob { get; set; }
        public string Allergy { get; set; }
        public string Medication { get; set; }
        public string BloodType { get; set; }
        public string Diabetic { get; set; }
        public string Surgery { get; set; }
        public string Vacinated { get; set; }


    }
}
