using HCMSapi.data;
using HCMSapi.Models;
using Microsoft.EntityFrameworkCore;

namespace HCMSapi.Repository.mySQL
{
    public class SpecialityRepository : IspecialityRepository
    {
        HCMSDbContext _dbContext;
        public SpecialityRepository(HCMSDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Speciality> getSpeciality()
        {
            return _dbContext.specialities.AsNoTracking().ToList();
        }
        public Speciality addSpeciality(Speciality speciality)
        {
            _dbContext.Add(speciality);
            _dbContext.SaveChanges();
            return speciality;
        }
        public Speciality getSpecialityById(int id)
        {
            return _dbContext.specialities.AsNoTracking().ToList().FirstOrDefault(c => c.Id == id);
        }
        public Speciality updateSpeciality(Speciality speciality)
        {
            _dbContext.specialities.Attach(speciality);
            _dbContext.Update(speciality);
            _dbContext.SaveChanges();
            return speciality;
        }
        public Speciality DeleteSpeciality(int Id)
        {
            var speciality = getSpecialityById(Id);
            _dbContext.Remove(speciality);
            _dbContext.SaveChanges();
            return speciality;
        }

    }
}
