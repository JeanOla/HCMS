using HCMS.Models;
using HCMS.Repository;
using HCMS.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HCMS.Controllers
{
    public class AppointmentController : Controller
    {
        IAppointmentRepository _repo;

        IDoctorScheduleRepository _schedule;
        private UserManager<ApplicationUser> _userManager { get; }

        public AppointmentController(IAppointmentRepository repo,UserManager<ApplicationUser> userManager, IDoctorScheduleRepository schedule)
        {
            _repo = repo;
            _userManager = userManager;
            _schedule = schedule;
        }
        public IActionResult Index()
        {
            if (User.IsInRole("Doctor"))
            {
                var UserId = _userManager.GetUserId(User);
                var appoint = _repo.getAllDoctorAppointment(UserId);
                return View(appoint);
            }
            var appointment = _repo.getAllAppointment();
            return View(appointment);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.optionsForCases = new SelectList(_repo.getAllCases(), "Id", "fullcase");
            ViewBag.optionsForDoctor = new SelectList(_repo.getAllDoctor(), "Id", "FullName");
            Appointment appointment = new Appointment();
            return View(appointment);
        }
        [HttpPost]
        public IActionResult Create(Appointment appoint)
        {
            ViewBag.optionsForCases = new SelectList(_repo.getAllCases(), "Id", "fullcase");
            ViewBag.optionsForDoctor = new SelectList(_repo.getAllDoctor(), "Id", "FullName");
            if (appoint.DoctorId == null || appoint.DoctorId == "")
            {
                ModelState.AddModelError("DoctorId", "Doctor is required to set an appointment.");
                return View(appoint);
            }
            var doctorSchedule = _schedule.GetDoctorSchedDayById(appoint.DoctorId, appoint.appointmentDay).FirstOrDefault();
            
            var startTime = DateTime.Parse(doctorSchedule.startTime.ToString());
            var endTime = DateTime.Parse(doctorSchedule.endTime.ToString());
            var appointmentTime = appoint.appointmentime;

            if (appointmentTime < startTime || appointmentTime > endTime)
            {
                ModelState.AddModelError("appointmentime", "Appointment time is outside the doctor's schedule.");
                return View(appoint);
            }
            if (appoint.appointmentDay == "")
            {
                ModelState.AddModelError("appointmentDay", "Appointment day is required.");
                return View(appoint);
            }

            _repo.addAppointment(appoint);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public async Task<IActionResult> Details(int Id)
        {
            ViewBag.optionsForCases = new SelectList(_repo.getAllCases(), "Id", "fullcase");
            ViewBag.optionsForDoctor = new SelectList(_repo.getAllDoctor(), "Id", "FullName");
            var details = _repo.GetAppointmentById(Id);
            return View(details);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int Id)
        {
            ViewBag.optionsForCases = new SelectList(_repo.getAllCases(), "Id", "fullcase");
            ViewBag.optionsForDoctor = new SelectList(_repo.getAllDoctor(), "Id", "FullName");


            var details = _repo.GetAppointmentById(Id);
            return View(details);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Appointment app)
        {
            ViewBag.optionsForCases = new SelectList(_repo.getAllCases(), "Id", "fullcase");
            ViewBag.optionsForDoctor = new SelectList(_repo.getAllDoctor(), "Id", "FullName");
            if (app.DoctorId == null || app.DoctorId == "")
            {
                ModelState.AddModelError("DoctorId", "Doctor is required to set an appointment.");
                return View(app);
            }
            var doctorSchedule = _schedule.GetDoctorSchedDayById(app.DoctorId, app.appointmentDay).FirstOrDefault();

            var startTime = DateTime.Parse(doctorSchedule.startTime.ToString());
            var endTime = DateTime.Parse(doctorSchedule.endTime.ToString());
            var appointmentTime = app.appointmentime;

            if (appointmentTime < startTime || appointmentTime > endTime)
            {
                ModelState.AddModelError("appointmentime", "Appointment time is outside the doctor's schedule.");
                return View(app);
            }
            if (app.appointmentDay == "")
            {
                ModelState.AddModelError("appointmentDay", "Appointment day is required.");
                return View(app);
            }

            _repo.updateAppointment(app);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int Id)
        {
            _repo.DeleteAppointment(Id);
            return RedirectToAction(controllerName: "Appointment", actionName: "index");
        }

        [HttpPost]
        public IActionResult changeDay(string newDay)
        {
            var doctors = _repo.getAllDoctorByDay(newDay);
            var options = new List<SelectListItem>();

            foreach (var doctor in doctors)
            {
                options.Add(new SelectListItem
                {
                    Value = doctor.doctorId.ToString(),
                    Text = doctor.User.FullName
                });
            }
            return Json(options);
        }

    }
}
