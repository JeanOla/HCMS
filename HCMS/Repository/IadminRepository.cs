using HCMS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HCMS.Repository
{
    public interface IadminRepository
    {
        List<ApplicationUser> getUserList();
        ApplicationUser DeleteAdmin(string Id);

    }
}
