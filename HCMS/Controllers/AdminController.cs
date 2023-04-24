using HCMS.Models;
using HCMS.Repository;
using HCMS.ViewModel;
using Microsoft.AspNetCore.Authorization;
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
            var admin = _repo.getUserList();
            if (admin.Any(a => a.Email == userViewModel.Email))
            {
                ModelState.AddModelError("Email", "Email address you entered is already in used.");
                return View(userViewModel);
            }
            if (admin.Any(a => a.FullNameWithMiddle.Equals(userViewModel.FullNameWithMiddle, StringComparison.OrdinalIgnoreCase)))
            {
                ModelState.AddModelError("FullNameWithMiddle", "Admin you entered is already existing.");
                return View(userViewModel);
            }
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
                var result = await _userManager.CreateAsync(userMode, userViewModel.password);
                if (result.Succeeded)
                {
                    var role = _roleManager.Roles.FirstOrDefault(r => r.Name == "Admin");
                    if (role != null)
                    {
                        var roleResult = await _userManager.AddToRoleAsync(userMode, role.Name);
                        if (!roleResult.Succeeded)
                        {
                            ModelState.AddModelError(String.Empty, "User Role cannot be assigned");
                            return View(userViewModel);
                        }
                    }
                    return RedirectToAction("AdminList");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("FullNameWithMiddle", error.Description);
                    return View(userViewModel);
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
            var oldemail = _repo.getAdminById(user.Id);
            var doctor = _repo.getAdminsExcept(oldemail.Email);
            if (doctor.Any(a => a.Email == user.Email))
            {
                ModelState.AddModelError("Email", "Email address you entered is already in used.");
                return View(user);
            }
            if (ModelState.IsValid)
            {
                var entityToUpdate = await _userManager.FindByIdAsync(user.Id);

                if (entityToUpdate != null)
                {
                    entityToUpdate.firstName = user.firstName;
                    entityToUpdate.lastName = user.lastName;
                    entityToUpdate.middleName = user.middleName;
                    entityToUpdate.dob = user.dob;
                    entityToUpdate.address = user.address;
                    entityToUpdate.Gender = user.gender;
                    entityToUpdate.PhoneNumber = user.PhoneNumber;
                    entityToUpdate.Email = user.Email;

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
        public IActionResult Delete(string Id)
        {
            _repo.DeleteAdmin(Id);
            return RedirectToAction("AdminList", "Admin");
        }


        [HttpGet]
        public IActionResult ChangePassword(string Id)
        {
            var user = _userManager.Users.FirstOrDefault(u => u.Id == Id);
            ChangePasswordViewModel userViewModel = new ChangePasswordViewModel()
            {
                Id = user.Id
            };
            return View(userViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = _repo.getAdminById(model.Id);
            var passwordIsValid = await _userManager.CheckPasswordAsync(user, model.CurrentPassword);
            if (!passwordIsValid)
            {
                ModelState.AddModelError("CurrentPassword", "The current password is incorrect.");
                return View(model);
            }
            
            if (user == null)
            {
                return NotFound();
            }

            var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
