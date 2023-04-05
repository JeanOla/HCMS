using HCMS.data;
using HCMS.Models;
using Microsoft.EntityFrameworkCore;

namespace HCMS.Repository.mySQL
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
        
    }
}
