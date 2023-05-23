using HCMS.data;
using HCMS.Migrations;
using HCMS.Models;
using HCMS.ViewModel;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NuGet.Common;
using System.Text;

namespace HCMS.Repository.mySQL
{
    public class CaseRepository : ICaseRepository
    {
        HCMSDbContext _dbContext;
        //api
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configs;
        public CaseRepository(HCMSDbContext dbContext, IConfiguration configs)
        {
            _dbContext = dbContext;
            _httpClient = new HttpClient();
            _configs = configs;
            _httpClient.BaseAddress = new Uri("http://localhost:5090");
        }

        public List<Patient> GetPatients()
        {
            return _dbContext.patients.AsNoTracking().ToList();
        }
        public async Task<Cases?> addCase(addCaseViewModel cases, string token)
        {
            //api
            var newcaseAsString = JsonConvert.SerializeObject(cases);
            var requestBody = new StringContent(newcaseAsString, Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Add("ApiKey", "RANDomValuetoDenoteAPIKeyWithNumbers131235");
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var response = await _httpClient.PostAsync("/api/Case/Add PAtient Case", requestBody);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var casess = JsonConvert.DeserializeObject<Cases>(content);
                return casess;
            }

            return null;

            //entity framework
            //_dbContext.Add(cases);
            //_dbContext.SaveChanges();
            //return cases;
        }


        public async Task<List<Cases>> getCases(string token)
        {
            //api
            _httpClient.DefaultRequestHeaders.Add("ApiKey", _configs.GetValue<string>("ApiKey"));
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var response = await _httpClient.GetAsync("/api/Case/Get All Patient Cases");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var cases = JsonConvert.DeserializeObject<List<Cases>>(content);

                foreach (var caseInstance in cases)
                {
                    caseInstance.patient = GetPatients().FirstOrDefault(p => p.Id == caseInstance.patientId);
                }
                return cases ?? new List<Cases>();
            }

            return new List<Cases>();
            //entity framework
            // return _dbContext.cases.Include(p => p.patient).AsNoTracking().ToList();
        }



        public Cases GetCaseById(int id)
        {
            return _dbContext.cases.Include(p => p.patient).AsNoTracking().ToList().FirstOrDefault(c => c.Id == id);
        }
        public async Task<Cases?> updateCase(UpdateCaseViewModel casee, string token)
        {
            //api
            var newCaseAsString = JsonConvert.SerializeObject(casee);
            var responseBody = new StringContent(newCaseAsString, Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Add("ApiKey", "RANDomValuetoDenoteAPIKeyWithNumbers131235");
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var response = await _httpClient.PutAsync($"/api/case/{casee.Id}", responseBody);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var cases = JsonConvert.DeserializeObject<Cases>(content);
                return cases;
            }

            return null;

            //entity frame work
            /* _dbContext.cases.Attach(casee);
             _dbContext.Update(casee);
             _dbContext.SaveChanges();
             return casee;*/
        }
        public async Task<Cases?> DeleteCase(int Id, string token)
        {
            //API
            var Case = GetCaseById(Id);

            _httpClient.DefaultRequestHeaders.Add("ApiKey", "RANDomValuetoDenoteAPIKeyWithNumbers131235");
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

           await _httpClient.DeleteAsync($"/api/case/{Id}");

            return Case;




            //entity framework
            //    var Case = GetCaseById(Id);
            //    _dbContext.Remove(Case);
            //    _dbContext.SaveChanges();
            //    return Case;
            //}

        }

        public List<Cases> getAllCases()
        {
            return _dbContext.cases.Include(p => p.patient).AsNoTracking().ToList();
        }
    }
}
