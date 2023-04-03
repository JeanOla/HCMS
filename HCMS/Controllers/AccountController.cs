using HCMS.Models;
using HCMS.Repository;
using HCMS.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HCMS.Controllers
{
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
                    await _userManager.AddToRoleAsync(userMode,role.Name);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(userViewModel);
        }
        public async Task<ActionResult> Index()//display doctor list
        {
            var doc = _repo.getDoctors();
             return View(doc);

       
        }
        [HttpGet]
        public IActionResult login()
        {
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



    }
}
