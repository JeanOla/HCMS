using HCMSapi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HCMSapi.Repository
{
    public interface IadminRepository
    {
        List<ApplicationUser> getUserList();
        //ApplicationUser DeleteAdmin(string Id);

    }
}
