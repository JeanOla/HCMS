using AutoMapper;
using HCMSapi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;
using HCMSapi.Models;
using HCMSapi.DTO;

namespace HCMSapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorScheduleController : ControllerBase
    {
        IDoctorScheduleRepository _repo;

        // HCMSDbContext _HCMSDbContext;

        private readonly IMapper _mapper;
        public DoctorScheduleController(IDoctorScheduleRepository doctorScheduleRepository, IMapper mapper)
        {
            _repo = doctorScheduleRepository;
            _mapper = mapper;
        }
        [HttpGet("Get All Doctor Schedule")]
        public IActionResult getDoctorSchedules()
        {

            /*List<Schedule> sched;
            try
            {
                sched = _repo.ScheduleList();
                if (sched == null)
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
            var json = JsonSerializer.Serialize(sched, options);

            return Ok(json);*/

            try
            {
                var schedules = _repo.ScheduleList().Select(s => new
                {
                    DoctorName = s.User.FullName,
                    DayOfWeek = s.dayOfWeek,
                    StartTime = s.startTime?.ToString("hh:mm tt"),
                    EndTime = s.endTime?.ToString("hh:mm tt")
                }).ToList();

                if (schedules.Count == 0)
                {
                    return NoContent();
                }

                return Ok(schedules);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("Add Doctor Schedule")]
        public IActionResult AddSchedule([FromBody] AddDoctorScheduleDTO schedule)
        {
            try
            {
                var sched = _mapper.Map<Schedule>(schedule);
                var addedSchedule = _repo.addSchedule(sched);
                return Ok(addedSchedule);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }



    }
}
