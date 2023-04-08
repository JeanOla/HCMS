using HCMS.Models;
using HCMS.Repository;
using HCMS.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HCMS.Controllers
{
    public class DoctorScheduleController : Controller
    {
        IDoctorScheduleRepository _repo;
        private UserManager<ApplicationUser> _userManager { get; }
        // login user details 
        private SignInManager<ApplicationUser> _signInManager { get; }

        private RoleManager<IdentityRole> _roleManager { get; }
        public DoctorScheduleController(UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager, IDoctorScheduleRepository repo,
        RoleManager<IdentityRole> RoleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = RoleManager;
            _repo = repo;
        }
        public IActionResult DoctorScheduleList()
        {
            var sched = _repo.ScheduleList();
            return View(sched);
        }
        [HttpGet]
        public IActionResult addDoctorSchedule()
        {
            
            ViewBag.options = new SelectList(_repo.getDoctors(), "Id", "FullName");
            Schedule schedule = new Schedule();
            return View(schedule);
        }
        [HttpPost]
        public IActionResult addDoctorSchedule(Schedule sched)
        {
           _repo.addSchedule(sched);
            return RedirectToAction("DoctorScheduleList");
        }
        [HttpGet]
        public IActionResult Update(int Id)
        {
            ViewBag.options = new SelectList(_repo.getDoctors(), "Id", "FullName");
            var details = _repo.GetDoctorSchedById(Id);
            return View(details);
        }
        [HttpPost]
        public IActionResult Update(Schedule sched)
        {
            _repo.updateSchedule(sched);
            return RedirectToAction("DoctorScheduleList");
        }
    }
}
