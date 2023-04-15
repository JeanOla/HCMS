using HCMS.Models;
using HCMS.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HCMS.Controllers
{
    public class SpecialityController : Controller
    {
        IspecialityRepository _repo;
        public SpecialityController(IspecialityRepository repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            var spe = _repo.getSpeciality();
            return View(spe);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Speciality speciality)
        {
            var special = _repo.getSpeciality();
            if (special.Any(a => a.SpecialityName.Equals(speciality.SpecialityName, StringComparison.OrdinalIgnoreCase)))
            {//check if there is already ongoing appointment for this case
                ModelState.AddModelError("SpecialityName", "Speciality you entered is Already Existing.");
                return View(speciality);
            }
            _repo.addSpeciality(speciality);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int Id)
        {
            var s = _repo.getSpecialityById(Id);
            return View(s);
        }
        [HttpPost]
        public IActionResult Update(Speciality speciality)
        {
            if (ModelState.IsValid)
            {
                _repo.updateSpeciality(speciality);
                return RedirectToAction("Index");
            }
            return View(speciality);
        }
        public IActionResult Delete(int Id)
        {
            _repo.DeleteSpeciality(Id);
            return RedirectToAction("Index");
        }
    }
}
