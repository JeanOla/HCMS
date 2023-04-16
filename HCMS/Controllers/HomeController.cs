using HCMS.Models;
using HCMS.Repository;
using HCMS.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HCMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IPatientRepository _patientRepository;
        IAppointmentRepository _appointmentRepository;
        IDoctorRepository _doctorRepository;
        IDoctorScheduleRepository _doctorScheduleRepository;
        
        private UserManager<ApplicationUser> _userManager { get; }
        public HomeController(ILogger<HomeController> logger, IPatientRepository patientRepository, 
            IAppointmentRepository appointmentRepository,IDoctorRepository doctorRepository,
            IDoctorScheduleRepository doctorScheduleRepository, UserManager<ApplicationUser> userManager )
        {
            _logger = logger;
            _patientRepository = patientRepository;
             _appointmentRepository = appointmentRepository;
            _doctorRepository = doctorRepository;
            _doctorScheduleRepository = doctorScheduleRepository;
                _userManager = userManager;
        }

        public IActionResult Index(DashboardViewModel dashboard)
        {
            
            if (User.IsInRole("Doctor"))
            {
                var UserId = _userManager.GetUserId(User);

                dashboard.totalPatient = _patientRepository.countPatient();
                dashboard.appointmentCountToday = _appointmentRepository.appointmentTodayById(UserId);
                //dashboard.doctorAvailableTodayCount = _doctorScheduleRepository.getDoctorsAvailableToday();
                return View(dashboard);
            }
            dashboard.totalPatient = _patientRepository.countPatient();
            dashboard.appointmentCountToday = _appointmentRepository.appointmentToday();
            dashboard.doctorAvailableTodayCount = _doctorScheduleRepository.getDoctorsAvailableToday();
            return View(dashboard);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}