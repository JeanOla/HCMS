using HCMSapi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;
using HCMSapi.Models;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using HCMSapi.DTO;
using AutoMapper;

namespace HCMSapi.Controllers
{
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

            /*  List<Cases> cases;
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

              return Ok(json);*/

            try
            {
                var cases = _repo.getCases().Select(s => new
                {
                    PatientName = s.patient.FullName,
                    reason = s.reason,
                    DoctorDiagnosis = s.diagnosis,
                    TreatementPlan = s.treatmentPlan
                }).ToList();

                if (cases.Count == 0)
                {
                    return NoContent();
                }

                return Ok(cases);
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


    }
}
