using HCMSapi.Models;
using HCMSapi.DTO;
using HCMSapi.Models;
using Microsoft.AspNetCore.Identity;

namespace HCMSapi.Repository
{
    public interface IAccountRepository
    {
        Task<ApplicationUser> SignUpUserAsync(ApplicationUser user, string password);
        Task<SignInResult> SignInUserAsync(LoginDTO loginDTO);
        Task<ApplicationUser> FindUserByEmailAsync(string email);
        ApplicationUser DeleteUser(string email);
        List<ApplicationUser> getAllUser();
        ApplicationUser getUserByEmail(string email);

        List<ApplicationUser> getDoctors();
        List<ApplicationUser> getUserList();
    }
}

