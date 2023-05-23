using HCMS.Models;
using HCMS.Repository;
using HCMS.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace HCMS.Controllers
{//doctorController
   
    public class AccountController : Controller
    {
        IDoctorRepository _repo;
        private UserManager<ApplicationUser> _userManager { get; }
        // login user details 
        private SignInManager<ApplicationUser> _signInManager { get; }

        private RoleManager<IdentityRole> _roleManager { get; }

        
        public AccountController(UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager, IDoctorRepository repo,
        RoleManager<IdentityRole>RoleManager) 
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = RoleManager;
            _repo = repo;
        }
        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.options = new SelectList(_repo.populateSpeciality(), "Id", "SpecialityName");
            RegisterDoctorViewModel model = new RegisterDoctorViewModel();
            return View(model);
        }
        [Authorize(Roles ="Admin, Doctor")]
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
            var user = _repo.getDoctorById(model.Id) ;
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

        
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDoctorViewModel userViewModel)
        {
            ViewBag.options = new SelectList(_repo.populateSpeciality(), "Id", "SpecialityName");
            var admin = _repo.getDoctors();
            if (admin.Any(a => a.Email == userViewModel.Email))
            {
                ModelState.AddModelError("Email", "Email address you entered is already in used.");
                return View(userViewModel);
            }
            if (admin.Any(a => a.FullNameWithMiddle.Equals(userViewModel.FullNameWithMiddle, StringComparison.OrdinalIgnoreCase)))
            {
                ModelState.AddModelError("FullNameWithMiddle", "the Doctor you entered is already existing.");
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
                    specialityId = userViewModel.specialityId,
                    Gender = userViewModel.gender,
                    PhoneNumber = userViewModel.PhoneNumber,
                    medicalLicenseNumber = userViewModel.medicalLicenseNumber,


                };
                //_userManager= crud opedration for user
                //_signInManager=manages signins
               var result = await _userManager.CreateAsync(userMode, userViewModel.password);
                if(result.Succeeded)
                {
                   var role = _roleManager.Roles.FirstOrDefault(r=>r.Name == "Doctor");
                    if(role != null)
                    {
                        var roleResult = await _userManager.AddToRoleAsync(userMode, role.Name);
                        if (!roleResult.Succeeded)
                        {
                            ModelState.AddModelError(String.Empty, "User Role cannot be assigned");
                        }
                    }
                   
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("FullNameWithMiddle", error.Description);
                    return View(userViewModel);
                }
                return RedirectToAction("Index", "Account");
            }
           return View(userViewModel);
        }
        
        [HttpGet]
        public async Task<IActionResult> Update(string Id)
        {
            
            ViewBag.options = new SelectList(_repo.populateSpeciality(), "Id", "SpecialityName");
            var user = _userManager.Users.FirstOrDefault(u => u.Id == Id);
            var roles = await _userManager.GetRolesAsync(user);
            EditDoctorViewModel userViewModel = new EditDoctorViewModel()
            {

                Email = user.Email,
                firstName = user.firstName,
                lastName = user.lastName,
                middleName = user.middleName,
                dob = user.dob,
                address = user.address,
                gender = user.Gender,
                PhoneNumber = user.PhoneNumber,
                specialityId = user.specialityId ?? 0,
                medicalLicenseNumber = user.medicalLicenseNumber,
            };
            return View(userViewModel);
        }
        
        [HttpPost]
        public async Task<IActionResult> Update(EditDoctorViewModel user)
        {
            var oldemail = _repo.getDoctorById(user.Id);
            ViewBag.options = new SelectList(_repo.populateSpeciality(), "Id", "SpecialityName");
            var doctor = _repo.getDoctorsExcept(oldemail.Email);
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
                    entityToUpdate.specialityId = user.specialityId;
                    entityToUpdate.Email = user.Email;
                    entityToUpdate.medicalLicenseNumber = user.medicalLicenseNumber;

                    var result = await _userManager.UpdateAsync(entityToUpdate);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Account");
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
       
        public async Task<ActionResult> Index()//display doctor list
        {
            if (User.IsInRole("Doctor"))
            {
                var UserId = _userManager.GetUserId(User);
                var doctor = _repo.getDoctorsInfo(UserId);
                return View(doctor);
            }
            var doc = _repo.getDoctors();
            return View(doc);


        }
        [HttpGet]
        public IActionResult login()
        {
            if (User?.Identity.IsAuthenticated == true)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginUserViewModel userViewModel)
        {
            if (ModelState.IsValid)
                {

                var result = await _signInManager.PasswordSignInAsync(userViewModel.UserName, userViewModel.Password, userViewModel.RememberMe, false);
                //login cookie and transfter to the client 
                if (result.Succeeded)
                {
                    //return RedirectToAction("Index", "Home");
                    var res = await _repo.SignInUserAsync(userViewModel);

                    if (res is not null)
                    {

                        HttpContext.Session.SetString("JWToken", res);
                        return RedirectToAction("Index", "Home");
                    }
                    ModelState.AddModelError("validation", "invalid login credentials");
                }
                ModelState.AddModelError("validation", "invalid login credentials");


            }
            return View(userViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
       
        [HttpGet]
        
        public async Task<IActionResult> Details(string Id)
        {
            ViewBag.options = new SelectList(_repo.populateSpeciality(), "Id", "SpecialityName");
            var user = _userManager.Users.FirstOrDefault(u => u.Id == Id);
            var roles = await _userManager.GetRolesAsync(user);
            EditDoctorViewModel userViewModel = new EditDoctorViewModel()
            {
                Id = user.Id,
                Email = user.Email,
                firstName = user.firstName,
                lastName = user.lastName,
                middleName = user.middleName,
                dob = user.dob,
                address = user.address,
                gender = user.Gender,
                PhoneNumber = user.PhoneNumber,
                specialityId = user.specialityId ?? 0,
                medicalLicenseNumber = user.medicalLicenseNumber
            };
            return View(userViewModel);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(string Id)
        {
            _repo.DeleteDoctor(Id);
            return RedirectToAction(controllerName: "Account", actionName: "index");
        }





    }
}
