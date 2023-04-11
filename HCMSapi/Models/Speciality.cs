namespace HCMSapi.Models
{
    public class Speciality
    {
        public int Id { get; set; }
        public string SpecialityName { get; set; }
        public List<ApplicationUser> applicationUsers { get; set; }
    }
}
