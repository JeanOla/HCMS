using HCMSapi.Models;

namespace HCMSapi.Repository
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
