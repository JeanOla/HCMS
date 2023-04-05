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
            _repo.addCase(cases);
            return RedirectToAction("");
        }
    }
}
