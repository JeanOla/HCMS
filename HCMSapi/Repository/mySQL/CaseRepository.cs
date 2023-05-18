using HCMSapi.data;
using HCMSapi.Models;
using Microsoft.Data.SqlClient;
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
            //SP 
            var patientId = new SqlParameter("@patientId", cases.patientId);
            var diagnosis = new SqlParameter("@diagnosis", cases.diagnosis ?? (object)DBNull.Value);
            var treatmentPlan = new SqlParameter("@treatmentPlan", cases.treatmentPlan ?? (object)DBNull.Value);
            var reason = new SqlParameter("@reason", cases.reason);

           _dbContext.Database.ExecuteSqlRaw("EXEC addCase @patientId, @diagnosis, @treatmentPlan,@reason", patientId, diagnosis,treatmentPlan, reason );
            return cases;
            //entity framework
            //_dbContext.Add(cases);
            //_dbContext.SaveChanges();
            //return cases;

        }
        public List<Cases> getCases()
        {
            //stored procedure
            return _dbContext.cases.FromSqlRaw($"getCases").ToList();
            //entity framework
            //return _dbContext.cases.Include(p => p.patient).AsNoTracking().ToList();
        }
        public Cases GetCaseById(int id)
        {
            //stored procedure
            return _dbContext.cases.FromSqlRaw($"getCases").ToList().FirstOrDefault(c => c.Id == id);
            //entity framework
            //return _dbContext.cases.Include(p => p.patient).AsNoTracking().ToList().FirstOrDefault(c => c.Id == id);
        }
        public Cases updateCase(Cases cases)
        {
            var patientId = new SqlParameter("@patientId", cases.patientId);
            var diagnosis = new SqlParameter("@diagnosis", cases.diagnosis ?? (object)DBNull.Value);
            var treatmentPlan = new SqlParameter("@treatmentPlan", cases.treatmentPlan ?? (object)DBNull.Value);
            var reason = new SqlParameter("@reason", cases.reason);
            var Id = new SqlParameter("@Id", cases.Id);

            _dbContext.Database.ExecuteSqlRaw("EXEC updateCase @patientId, @diagnosis, @treatmentPlan,@reason,@Id ", patientId, diagnosis, treatmentPlan, reason, Id);
            return cases;
            //_dbContext.cases.Attach(casee);
            //_dbContext.Update(casee);
            //_dbContext.SaveChanges();
           // return casee;
        }
        public Cases DeleteCase(int Id)
        {
            //stored procedure
            var cases = GetCaseById(Id);

            var id = new SqlParameter("@Id",Id);
            _dbContext.Database.ExecuteSqlRaw("EXEC deleteCase @Id ", id);
            return cases;
            //entity framework
            //var Case = GetCaseById(Id);
            //_dbContext.Remove(Case);
            //_dbContext.SaveChanges();
            //return Case;
        }

    }
}
