using HCMS.Models;
using HCMS.Repository;
using HCMS.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace HCMS.Controllers
{
    public class AdminController : Controller
    {
        IadminRepository _repo;
        private UserManager<ApplicationUser> _userManager { get; }
        // login user details 
        private SignInManager<ApplicationUser> _signInManager { get; }

        private RoleManager<IdentityRole> _roleManager { get; }
        public AdminController(UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager, IadminRepository repo,
        RoleManager<IdentityRole> RoleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = RoleManager;
            _repo = repo;
        }
        public async Task<ActionResult> AdminList()
        {
            var admin = _repo.getUserList();
            return View(admin);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(RegisterAdminViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                var userMode = new ApplicationUser
                {
                    UserName = userViewModel.Email,
                    Email = userViewModel.Email,
                    firstName = userViewModel.firstName,
                    lastName = userViewModel.lastName,
                    middleName = userViewModel.middleName,
                    dob = userViewModel.dob,
                    address = userViewModel.address,
                    Gender = userViewModel.gender,
                    PhoneNumber = userViewModel.PhoneNumber,


                };
                //_userManager= crud opedration for user
                //_signInManager=manages signins
                var result = await _userManager.CreateAsync(userMode, userViewModel.password);
                if (result.Succeeded)
                {
                    var role = _roleManager.Roles.FirstOrDefault(r => r.Name == "Admin");
                    await _userManager.AddToRoleAsync(userMode, role.Name);
                    return RedirectToAction("AdminList", "Admin");
                }
            }
            return View(userViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Update(string Id)
        {
            var user = _userManager.Users.FirstOrDefault(u => u.Id == Id);
            var roles = await _userManager.GetRolesAsync(user);
            EditAdminViewModel userViewModel = new EditAdminViewModel()
            {
             
                Email = user.Email,
                firstName = user.firstName,
                lastName = user.lastName,
                middleName = user.middleName,
                dob = user.dob,
                address = user.address,
                gender = user.Gender,
                PhoneNumber = user.PhoneNumber,
            };
            return View(userViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Update(EditAdminViewModel user)
        {
            
            if (ModelState.IsValid)
            {
                var entityToUpdate = await _userManager.FindByEmailAsync(user.Email);

                if (entityToUpdate != null)
                {
                    entityToUpdate.firstName = user.firstName;
                    entityToUpdate.lastName = user.lastName;
                    entityToUpdate.middleName = user.middleName;
                    entityToUpdate.dob = user.dob;
                    entityToUpdate.address = user.address;
                    entityToUpdate.Gender = user.gender;
                    entityToUpdate.PhoneNumber = user.PhoneNumber;

                    var result = await _userManager.UpdateAsync(entityToUpdate);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("AdminList", "Admin");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }
                else
                {
                    return NotFound();
                }
            }
            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string Id)
        {
            var user = _userManager.Users.FirstOrDefault(u => u.Id == Id);
            var roles = await _userManager.GetRolesAsync(user);
            EditAdminViewModel userViewModel = new EditAdminViewModel()
            {

                Email = user.Email,
                firstName = user.firstName,
                lastName = user.lastName,
                middleName = user.middleName,
                dob = user.dob,
                address = user.address,
                gender = user.Gender,
                PhoneNumber = user.PhoneNumber,
            };
            return View(userViewModel);
        }
    }
}
