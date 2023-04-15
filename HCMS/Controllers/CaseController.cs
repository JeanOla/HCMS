using HCMS.Models;
using HCMS.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HCMS.Controllers
{
    public class CaseController : Controller
    {
        ICaseRepository _repo;
        public CaseController(ICaseRepository repo)
        {
            
            _repo = repo;
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.options = new SelectList(_repo.GetPatients(), "Id", "FullName");
            Cases casess = new Cases();
            return View(casess);
        }
        [HttpPost]
        public IActionResult Create(Cases cases)
        {
            ViewBag.options = new SelectList(_repo.GetPatients(), "Id", "FullName");
            var caseee = _repo.getCases();
            if (caseee.Any(a => a.rawcase.Equals(cases.rawcase, StringComparison.OrdinalIgnoreCase)))
            {//check if there is already ongoing appointment for this case
                ModelState.AddModelError("rawcase", "Patient Case Already Exist.");
                return View(cases);
            }
            _repo.addCase(cases);
            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {
           var casee = _repo.getCases();
            return View(casee);
        }
        [HttpGet]
        public IActionResult Details(int Id)
        {
            ViewBag.options = new SelectList(_repo.GetPatients(), "Id", "FullName");
            var casee = _repo.GetCaseById(Id);
            return View(casee);
        }
        [HttpGet]
        public IActionResult Update(int Id)
        {
            ViewBag.options = new SelectList(_repo.GetPatients(), "Id", "FullName");
            var casee = _repo.GetCaseById(Id);
            return View(casee);
        }
        [HttpPost]
        public IActionResult Update(Cases cases)
        {
            _repo.updateCase(cases);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int Id)
        {
           _repo.DeleteCase(Id);
            return RedirectToAction("Index");
        }
    }
}
