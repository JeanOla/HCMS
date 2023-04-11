using AutoMapper;
using HCMSapi.Models;
using HCMSapi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using HCMSapi.DTO;
using HCMSapi.data;
using Microsoft.AspNetCore.Authorization;


namespace HCMSapi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        IPatientRepository _repo;

       // HCMSDbContext _HCMSDbContext;

       // private readonly IMapper _mapper;
        public PatientController(IPatientRepository patientRepository)
        {
            _repo = patientRepository;
           // _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_repo.getPatients());
        }

        [HttpGet("{Id}")]
        public IActionResult GetPatienById([FromRoute] int Id)
        {
            if (Id == 0)
                return BadRequest();
            Patient patient;
            try
            {
                patient = _repo.GetPatienById(Id);
                if (patient == null)
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
            var json = JsonSerializer.Serialize(patient, options);

            return Ok(json);
        }
        [HttpPost]
        public IActionResult AddPatientAndMedicalRecord([FromBody] PatientAndMedicalRecordDto viewModel)
        {
            if (ModelState.IsValid)
            {
                var newPatient = new Patient
                {
                    // Map properties from the view model to the Patient model
                    firstName = viewModel.FirstName,
                    lastName = viewModel.LastName,
                    middleName = viewModel.MiddleName,
                    Email = viewModel.Email,
                    address = viewModel.Address,
                    phone = viewModel.Phone,
                    gender = viewModel.Gender,
                    dob = viewModel.Dob
                };

                var newMedicalRecord = new MedicalRecord
                {
                    // Map properties from the view model to the MedicalRecord model
                    allergy = viewModel.Allergy,
                    medication = viewModel.Medication,
                    bloodType = viewModel.BloodType,
                    diabetic = viewModel.Diabetic,
                    surgery = viewModel.Surgery,
                    vacinated = viewModel.Vacinated
                };

               
                var result = _repo.AddPatientAndMedicalRecord(newPatient,newMedicalRecord);

                if (result != null)
                {
                    // Return a 201 Created response with the newly created patient and medical record
                    return CreatedAtAction(nameof(GetHashCode), new { id = result.Patient.Id }, result);
                }
            }

            // Return a 400 Bad Request response if the model state is invalid
            return BadRequest(ModelState);
        }


    }

}
