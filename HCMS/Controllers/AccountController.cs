using HCMS.Models;
using HCMS.Repository;
using HCMS.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
        [HttpPost]
        public async Task<IActionResult> Register(RegisterDoctorViewModel userViewModel)
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
                    specialityId = userViewModel.specialityId,
                    Gender = userViewModel.gender,
                    PhoneNumber = userViewModel.PhoneNumber,


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
                    //return RedirectToAction("Index", "Home");
                }
            }
           return RedirectToAction("Index");
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
            };
            return View(userViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(EditDoctorViewModel user)
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
                    entityToUpdate.specialityId = user.specialityId;
                   // entityToUpdate.PasswordHash = user.password;


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
            if(User?.Identity.IsAuthenticated == true)
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
                // login activity -> cookie [Roles and Claims]
                var result = await _signInManager.PasswordSignInAsync(userViewModel.UserName, userViewModel.Password, userViewModel.RememberMe, false);
                //login cookie and transfter to the client 
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, "invalid login credentials");
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
            };
            return View(userViewModel);
        }

        public IActionResult Delete(string Id)
        {
            _repo.DeleteDoctor(Id);
            return RedirectToAction(controllerName: "Account", actionName: "index");
        }





    }
}
