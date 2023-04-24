using AutoMapper;
using HCMSapi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using System.Text.Json;
using HCMSapi.Models;
using HCMSapi.DTO;
using Microsoft.AspNetCore.Authorization;

namespace HCMSapi.Controllers
{
    [Authorize]
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
            var doctorsched = _repo.DoctorScheduleList(schedule.doctorId);
            try
            {
                if (doctorsched.Any(s => s.dayOfWeek == schedule.dayOfWeek))
                {
                    return BadRequest("There is already a schedule for this day.");
                }
                if (schedule.startTime.HasValue && schedule.endTime.HasValue && schedule.startTime.Value >= schedule.endTime.Value)
                {
                    return BadRequest("Start time must be before the end time.");
                    
                }
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
