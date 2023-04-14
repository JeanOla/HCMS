using HCMS.Models;
using HCMS.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HCMS.Controllers
{
    public class PatientViewModel
    {
        public Patient NewPatient { get; set; }
        public MedicalRecord Medred { get; set; }
    }

    public class PatientController : Controller
    {
        IPatientRepository _repo;
        //public IActionResult Index()
        //{
        //    return View();
        //}
        
        public PatientController(IPatientRepository repo)
        {
            _repo = repo;
        }
        [Authorize]
        public IActionResult index()
        {   
            var emp = _repo.getPatients();

            return View(emp);

        }
        [Authorize]
        public IActionResult Details(int Id)
        {
            var patient = _repo.GetPatienById(Id);
            return View(patient);
        }
        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            return View();

        }
        [Authorize]
        [HttpPost]
        public IActionResult Create(Patient newPatient, MedicalRecord medred)
        {
            var patient = _repo.getPatients();
            if (patient.Any(a => a.Name == newPatient.Name))
            {//check if there is already ongoing appointment for this case
                ModelState.AddModelError("Name", "Patient Already Exist.");
                return View(newPatient);
            }

            _repo.AddPatientAndMedicalRecord(newPatient, medred);
            return RedirectToAction("index");

        }
        [Authorize]
        [HttpGet]
        public IActionResult edit(int Id)
        {
            var oldEmp = _repo.GetPatienById(Id);
            return View(oldEmp);
        }
        [Authorize]
        [HttpPost]
        public IActionResult edit(Patient newPatient, MedicalRecord medred)
        {
          var p = _repo.editPatient(newPatient,medred);
            return RedirectToAction("index");
        }
        [Authorize]
        public IActionResult delete(int Id)
        {
            _repo.DeletePatient(Id);
            return RedirectToAction(controllerName: "Patient", actionName: "index");
        }

    }
}
