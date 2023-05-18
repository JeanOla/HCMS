using HCMSapi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;
using HCMSapi.Models;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using HCMSapi.DTO;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace HCMSapi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CaseController : ControllerBase
    {
        ICaseRepository _repo;

        // HCMSDbContext _HCMSDbContext;

        private readonly IMapper _mapper;
        public CaseController(ICaseRepository caseRepository,IMapper mapper)
        {
            _repo = caseRepository;
             _mapper = mapper;
        }
        [HttpGet("Get All Patient Cases")]
        public IActionResult getPatientCases()
        {
            try
            {
                /* var cases = _repo.getCases().Select(s => new
                 {
                     Id = s.Id,
                     PatientName = s.patient.FullName,
                     reason = s.reason,
                     DoctorDiagnosis = s.diagnosis,
                     TreatementPlan = s.treatmentPlan
                 }).ToList();

                 if (cases.Count == 0)
                 {
                     return NoContent();
                 }

                 return Ok(cases);*/
                /*List<Cases> cases;
                try
                {
                    cases = _repo.getCases();
                    if (cases == null)
                        return NoContent();
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
                var options = new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.Preserve,
                    MaxDepth = 32,
                    WriteIndented = true
                };
                var json = JsonSerializer.Serialize(cases, options);
                */
                return Ok(_repo.getCases());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("Add PAtient Case")]
        public IActionResult AddPatientCase([FromBody] addPatientCaseDTO addPatientCase)
        {
            if (addPatientCase == null)
                return BadRequest("No data provided");
            if (ModelState.IsValid)
            {
                var caase = _mapper.Map<Cases>(addPatientCase);

                var newcase = _repo.addCase(caase);
                // return the url for it
                return CreatedAtAction("getPatientCasesById", new { Id = newcase.Id }, newcase);
                //return CreatedAtAction("GetById",new { todoId = newtodo.Id },null); // json or xml
            }
            return BadRequest(ModelState);
        }
        [HttpGet("Get Patient Case By {Id}")]
        public IActionResult getPatientCasesById([FromRoute] int Id)
        {
            if (Id == 0)
                return BadRequest();
            Cases cases;
            try
            {
                cases = _repo.GetCaseById(Id);
                if (cases == null)
                    return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            return Ok(cases);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCase(int id, [FromBody] UpdateCasaeDTO updatedCase)
        {
            var existingCase = _repo.GetCaseById(id);

            if (existingCase == null)
            {
                return NotFound();
            }
            existingCase.Id = id;
            existingCase.reason = updatedCase.reason;
            existingCase.treatmentPlan = updatedCase.treatmentPlan;
            existingCase.diagnosis = updatedCase.diagnosis;
            existingCase.patientId = updatedCase.patientId;
           // var caase = _mapper.Map<Cases>(updatedCase);
            _repo.updateCase(existingCase);
            return Ok(updatedCase);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCase(int id)
        {
            var existingCase = _repo.GetCaseById(id);

            if (existingCase == null)
            {
                return NotFound();
            }
            _repo.DeleteCase(id);
            return Ok(existingCase);
        }

    }
}
