using HCMS.Models;

namespace HCMS.Repository
{
    public interface ICaseRepository
    {
        List<Patient> GetPatients();
        Cases addCase(Cases cases);

        List<Cases> getCases();
    }
}
