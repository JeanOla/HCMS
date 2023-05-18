using HCMS.data;
using HCMS.Models;
using HCMS.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using NuGet.Protocol.Plugins;
using System.Net.Http;
using System.Runtime.ExceptionServices;
using System.Text;

namespace HCMS.Repository.mySQL
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configs;

        HCMSDbContext _dbContext;
        private RoleManager<IdentityRole> _roleManager { get; }
        public DoctorRepository(HCMSDbContext dbContext, RoleManager<IdentityRole> roleManager, IConfiguration configs)
        {
            _dbContext = dbContext;
            _roleManager = roleManager;
            _httpClient = new HttpClient();
            _configs = configs;
            _httpClient.BaseAddress = new Uri("http://localhost:5090");
        }
        public List<Speciality> populateSpeciality()
        {
         
            return _dbContext.specialities.ToList();
        }
        public List<ApplicationUser> getDoctors()
        {
            var role = _roleManager.Roles.ToList();
           
           return _dbContext.users.Include(s=>s.speciality).Where(s=>s.speciality.SpecialityName != null).AsNoTracking().ToList();
        }
        public List<ApplicationUser> getDoctorsInfo(string Id)
        {
            var role = _roleManager.Roles.ToList();
            return _dbContext.users.Include(s => s.speciality).Where(d => d.Id == Id).AsNoTracking().ToList();
            //return _dbContext.users.Include(s => s.speciality).Where(s => s.speciality.SpecialityName != null).AsNoTracking().ToList();
        }
        public ApplicationUser DeleteDoctor(string Id)
        {
            var doctor = _dbContext.users.AsNoTracking().ToList().FirstOrDefault(d => d.Id == Id);
            _dbContext.Remove(doctor);
            _dbContext.SaveChanges();
            return doctor;

        }
        public ApplicationUser getDoctorById(string Id)
        {
            return _dbContext.users.AsNoTracking().ToList().FirstOrDefault(d => d.Id == Id);
        }
        public List<ApplicationUser> getDoctorsExcept(string email)
        {
            return _dbContext.users.Include(s => s.speciality).Where(s => s.speciality.SpecialityName != null && s.Email != email).AsNoTracking().ToList();

        }
        //new

        public async Task<string> SignInUserAsync(LoginUserViewModel loginUserViewModel)
        {
            // rest api call
            var newTodoAsString = JsonConvert.SerializeObject(loginUserViewModel);
            var requestBody = new StringContent(newTodoAsString, Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Add("ApiKey", _configs.GetValue<string>("ApiKey"));
            var response = await _httpClient.PostAsync("/api/Account/login", requestBody);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                // extract token from responce and store it in session
                var token = JObject.Parse(content)["token"].ToString();

                return token;
            }

            return null;
        }
    }
}
