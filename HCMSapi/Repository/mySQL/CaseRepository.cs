using HCMSapi.data;
using HCMSapi.Models;
using Microsoft.EntityFrameworkCore;

namespace HCMSapi.Repository.mySQL
{
    public class CaseRepository : ICaseRepository
    {
        HCMSDbContext _dbContext;
        public CaseRepository(HCMSDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Patient> GetPatients()
        {
            return _dbContext.patients.AsNoTracking().ToList();
        }
        public Cases addCase(Cases cases)
        {
            _dbContext.Add(cases);
            _dbContext.SaveChanges();
            return cases;
        }
        public List<Cases> getCases()
        {
            return _dbContext.cases.Include(p => p.patient).AsNoTracking().ToList();
        }
        public Cases GetCaseById(int id)
        {
            return _dbContext.cases.Include(p => p.patient).AsNoTracking().ToList().FirstOrDefault(c => c.Id == id);
        }
        public Cases updateCase(Cases casee)
        {
            _dbContext.cases.Attach(casee);
            _dbContext.Update(casee);
            _dbContext.SaveChanges();
            return casee;
        }
        public Cases DeleteCase(int Id)
        {
            var Case = GetCaseById(Id);
            _dbContext.Remove(Case);
            _dbContext.SaveChanges();
            return Case;
        }

    }
}
