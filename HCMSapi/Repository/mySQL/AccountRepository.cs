using HCMSapi.Models;
using HCMSapi.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using HCMSapi.data;

namespace HCMSapi.Repository.mySQL
{
    public class AccountRepository : IAccountRepository
    {
        HCMSDbContext _dbContext;
        public UserManager<ApplicationUser> _userManager { get; }
        public SignInManager<ApplicationUser> _signInManager { get; }

        public AccountRepository(UserManager<ApplicationUser> userManager,
                                   SignInManager<ApplicationUser> signInManager,HCMSDbContext hCMSDbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _dbContext = hCMSDbContext;
        }
        public async Task<ApplicationUser> SignUpUserAsync(ApplicationUser user, string password)
        {
            var newUser = await _userManager.CreateAsync(user, password);
            if (newUser.Succeeded)
                return user;
            return null;
        }
        public async Task<SignInResult> SignInUserAsync(LoginDTO loginDTO)
        {
            var loginResult = await _signInManager.PasswordSignInAsync(loginDTO.UserName, loginDTO.Password, loginDTO.RememberMe, false);
            return loginResult;
        }

        public async Task<ApplicationUser> FindUserByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user;
        }
        public ApplicationUser DeleteUser(string email)
        {
            var user = getUserByEmail(email);
            _dbContext.Remove(user);
            _dbContext.SaveChanges();
            return user;
        }
        public List<ApplicationUser> getAllUser()
        {
            return _dbContext.users.AsNoTracking().ToList();
        }

        public ApplicationUser getUserByEmail(string email)
        {
            return _dbContext.users.AsNoTracking().ToList().FirstOrDefault(e => e.Email == email);
        }
    }
}
