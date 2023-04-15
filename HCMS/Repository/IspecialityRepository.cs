using HCMS.Models;

namespace HCMS.Repository
{
    public interface IspecialityRepository
    {
        List<Speciality> getSpeciality();
        Speciality addSpeciality(Speciality speciality);
        Speciality getSpecialityById(int id);
        Speciality updateSpeciality(Speciality speciality);
        Speciality DeleteSpeciality(int Id);
    }
}
