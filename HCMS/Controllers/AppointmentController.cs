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
            if (appoint.DoctorId == null || appoint.DoctorId == "")// check if doctor is valid
            {
                ModelState.AddModelError("DoctorId", "Doctor is required to set an appointment.");
                return View(appoint);
            }
            var selectedAppointmentDay = appoint.appointmentDay;
            var appointmentDayOfWeek = selectedAppointmentDay.DayOfWeek.ToString(); // Get day of week as string
            var doctorSchedule = _schedule.GetDoctorSchedDayById(appoint.DoctorId, appointmentDayOfWeek).FirstOrDefault();

            var startTime = DateTime.Parse(doctorSchedule.startTime.ToString()).TimeOfDay;
            var endTime = DateTime.Parse(doctorSchedule.endTime.ToString()).TimeOfDay;
            var appointmentTime = appoint.appointmentime.TimeOfDay;

            if (selectedAppointmentDay < DateTime.Today)
            {
                ModelState.AddModelError("appointmentDay", "Selected appointment day has already passed.");
                return View(appoint);
            }

            if (appointmentTime < startTime || appointmentTime > endTime)
            {//check if selected of appointment time is valid based on doctor schedule
                ModelState.AddModelError("appointmentime", "Appointment time is outside the doctor's schedule.");
                return View(appoint);
            }
            var appointments = _repo.getAllAppointment();
            if (appointments.Any(a => a.caseId == appoint.caseId && a.Status == "Ongoing"))
            {//check if there is already ongoing appointment for this case
                ModelState.AddModelError("caseId", "This is case already have an appointment");
                return View(appoint);
            }
            if (appointments.Any(a => a.DoctorId == appoint.DoctorId && a.appointmentime == appoint.appointmentime && a.appointmentDay == appoint.appointmentDay && a.Status == appoint.Status))
            {//check if there is already ongoing appointment for this case
                ModelState.AddModelError("appointmentime", "There is already an appointment set in this time for the selected doctor. ");
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
            if (app.Status == "Done")
            {
                _repo.updateAppointment(app);
                return RedirectToAction("Index");
            }
            if (app.DoctorId == null || app.DoctorId == "")
            {
                ModelState.AddModelError("DoctorId", "Doctor is required to set an appointment.");
                return View(app);
            }
            var selectedAppointmentDay = app.appointmentDay;
            var appointmentDayOfWeek = selectedAppointmentDay.DayOfWeek.ToString(); // Get day of week as string
            var doctorSchedule = _schedule.GetDoctorSchedDayById(app.DoctorId, appointmentDayOfWeek).FirstOrDefault();

            var startTime = DateTime.Parse(doctorSchedule.startTime.ToString()).TimeOfDay;
            var endTime = DateTime.Parse(doctorSchedule.endTime.ToString()).TimeOfDay;
            var appointmentTime = app.appointmentime.TimeOfDay;

            if (appointmentTime < startTime || appointmentTime > endTime)
            {
                ModelState.AddModelError("appointmentime", "Appointment time is outside the doctor's schedule.");
                return View(app);
            }
            var appointments = _repo.getAllAppointment();
            //if (appointments.Any(a => a.caseId == app.caseId && a.Status == "Ongoing"))
            //{//check if there is already ongoing appointment for this case
            //    ModelState.AddModelError("caseId", "This is case already have an appointment");
            //    return View(app);
            //}

            if (selectedAppointmentDay < DateTime.Today)
            {
                ModelState.AddModelError("appointmentDay", "Selected appointment day has already passed.");
                return View(app);
            }
            if (appointments.Any(a => a.DoctorId == app.DoctorId && a.appointmentime == app.appointmentime && a.appointmentDay == app.appointmentDay && a.Status == app.Status))
            {//check if there is already ongoing appointment for this case
                ModelState.AddModelError("appointmentime", "There is already an appointment set in this time for the selected doctor. ");
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
        public IActionResult changeDay(DateTime newDay)
        {
            var doctors = _repo.getAllDoctorByDay(newDay.DayOfWeek.ToString());
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
