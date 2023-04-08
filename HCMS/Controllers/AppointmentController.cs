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
        public AppointmentController(IAppointmentRepository repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
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
            var employee = _repo.updateAppointment(app);
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
                    Value = doctor.Id.ToString(),
                    Text = doctor.User.FullName
                });
            }
            return Json(options);
        }
    }
}
