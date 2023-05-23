using HCMS.Models;
using HCMS.ViewModel;

namespace HCMS.Repository
{
    public interface ICaseRepository
    {
        List<Patient> GetPatients();
        // Cases addCase(Cases cases);
        Task<Cases?> addCase(addCaseViewModel cases, string token);
        Task<List<Cases>> getCases(string token);
        Cases GetCaseById(int id);
        //  Cases updateCase(Cases casee);
        Task<Cases?> updateCase(UpdateCaseViewModel casee, string token);
        // Cases DeleteCase(int Id, string token);
         Task<Cases?> DeleteCase(int Id, string token);
        List<Cases> getAllCases();

    }

}
