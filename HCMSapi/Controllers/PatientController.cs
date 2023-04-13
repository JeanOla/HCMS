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

        [HttpGet("Get Patient By {Id}")]
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
        [HttpPost("add Patient")]
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
                   
                    return CreatedAtAction("GetPatienById", new { Id = result.Patient.Id }, viewModel);
                }
            }

            return BadRequest(ModelState);
        }
        [HttpDelete("{Id}Delete Patient")]
        public IActionResult Delete([FromRoute] int Id) // model binding 
        {
            if (Id == 0)
                return BadRequest();
            var todo = _repo.GetPatienById(Id);
            if (todo == null)
                return NotFound("No resource found");
           _repo.DeletePatient(Id); 
            return Ok(_repo.getPatients());
        }
        /* [HttpPut("{Id} Update Patient Information")]
         public IActionResult UpdatePatient([FromBody] PatientAndMedicalRecordDto patientAndMedicalRecord, [FromRoute] int Id) // model binding // validation

         {


             if (patientAndMedicalRecord == null)
                 return BadRequest("No data provided");
             if (ModelState.IsValid)
             {
                 var updatePatient = _repo.editPatient(Id, todo);
                 return AcceptedAtAction("GetById", new { todoId = updatedTodo.Id }, updatedTodo); // json or xml
             }
             return BadRequest(ModelState);
         }*/

        [HttpPut("patients/{id}")]
        public ActionResult<PatientAndMedicalRecordDto> UpdatePatient([FromRoute]int id, [FromBody] PatientAndMedicalRecordDto dto)
        {
            var patient = _repo.GetPatienById(id);

            if (patient == null)
            {
                return NotFound();
            }

            // Update patient details
            patient.firstName = dto.FirstName;
            patient.lastName = dto.LastName;
            patient.middleName = dto.MiddleName;
            patient.Email = dto.Email;
            patient.address = dto.Address;
            patient.phone = dto.Phone;
            patient.gender = dto.Gender;
            patient.dob = dto.Dob;

            // Update medical record details
            var medicalRecord = patient.medical;
            medicalRecord.allergy = dto.Allergy;
            medicalRecord.medication = dto.Medication;
            medicalRecord.bloodType = dto.BloodType;
            medicalRecord.diabetic = dto.Diabetic;
            medicalRecord.surgery = dto.Surgery;
            medicalRecord.vacinated = dto.Vacinated;

            var updatedPatientAndMedicalRecord = _repo.editPatient(patient, medicalRecord);

            var updatedDto = new PatientAndMedicalRecordDto
            {
                FirstName = updatedPatientAndMedicalRecord.Patient.firstName,
                LastName = updatedPatientAndMedicalRecord.Patient.lastName,
                MiddleName = updatedPatientAndMedicalRecord.Patient.middleName,
                Email = updatedPatientAndMedicalRecord.Patient.Email,
                Address = updatedPatientAndMedicalRecord.Patient.address,
                Phone = updatedPatientAndMedicalRecord.Patient.phone,
                Gender = updatedPatientAndMedicalRecord.Patient.gender,
                Dob = updatedPatientAndMedicalRecord.Patient.dob,
                Allergy = updatedPatientAndMedicalRecord.MedicalRecord.allergy,
                Medication = updatedPatientAndMedicalRecord.MedicalRecord.medication,
                BloodType = updatedPatientAndMedicalRecord.MedicalRecord.bloodType,
                Diabetic = updatedPatientAndMedicalRecord.MedicalRecord.diabetic,
                Surgery = updatedPatientAndMedicalRecord.MedicalRecord.surgery,
                Vacinated = updatedPatientAndMedicalRecord.MedicalRecord.vacinated
            };

            return Ok(updatedDto);
        }
    }

}
