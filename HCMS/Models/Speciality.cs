using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace HCMS.Models
{
    public class Speciality
    {
        public int Id { get; set; }
        public string SpecialityName { get; set; }
        [ValidateNever]
        public List<ApplicationUser> applicationUsers { get; set; }
    }
}
