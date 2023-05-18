using HCMS.Migrations;
using HCMS.Models;
using HCMS.Repository;
using HCMS.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualBasic;

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
            var token = HttpContext.Session.GetString("JWToken");
            if (token == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.options = new SelectList(_repo.GetPatients(), "Id", "FullName");
            Cases casess = new Cases();
            return View(casess);
        }
      
        [HttpPost]
        public async Task<IActionResult> Create(addCaseViewModel cases)
        {
            var token = HttpContext.Session.GetString("JWToken");
            ViewBag.options = new SelectList(_repo.GetPatients(), "Id", "FullName");
            //var caseee = await _repo.getCases(token);
            //if (caseee.Any(a => a.rawcase.Equals(cases.rawcase, StringComparison.OrdinalIgnoreCase)))
            //{//check if there is already ongoing appointment for this case
            //    ModelState.AddModelError("rawcase", "Patient Case Already Exist.");
            //    return View(cases);
            //}
            if (cases.patientId == null || cases.patientId == 0)
            {
                ModelState.AddModelError("patientId", "Patient is required");
                return View(cases);
            }
            if (string.IsNullOrEmpty(cases.reason))
            {
                ModelState.AddModelError("reason", "reason for consultation is required");
                return View(cases);
            }
            await _repo.addCase(cases, token);
            return RedirectToAction("Index");
        }
        public async Task <IActionResult> Index()
        {
            var token = HttpContext.Session.GetString("JWToken");
            var cases = await _repo.getCases(token);

            //var casee = _repo.getCases(token);
            return View(cases);
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
        public async Task<IActionResult> Update(UpdateCaseViewModel cases)
        {
            var token = HttpContext.Session.GetString("JWToken");
            await _repo.updateCase(cases,token);
            return RedirectToAction("Index");
        }
       // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int Id)
        {
            var token = HttpContext.Session.GetString("JWToken");
            var res = _repo.GetCaseById(Id);
            if (res == null)
            {
                return RedirectToAction("Index");
            }
           await _repo.DeleteCase(Id,token);
            return RedirectToAction("Index");
        }
    }
}
