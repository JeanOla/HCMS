using HCMS.Models;
using HCMS.Repository;
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
    }
}
