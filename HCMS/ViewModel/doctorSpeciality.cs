using HCMS.Models;

namespace HCMS.ViewModel
{
    public class doctorSpeciality
    {
        public int Id { get; set; }
        public string SpecialityName { get; set; }
        public List<RegisterDoctorViewModel> registerDoctorViewModels { get; set; }
    }
}
