﻿using HCMSapi.data;
using HCMSapi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HCMSapi.Repository.mySQL
{
    public class DoctorRepository : IDoctorRepository
    {
        HCMSDbContext _dbContext;
        private RoleManager<IdentityRole> _roleManager { get; }
        public DoctorRepository(HCMSDbContext dbContext, RoleManager<IdentityRole> roleManager)
        {
            _dbContext = dbContext;
            _roleManager = roleManager;
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
    }
}
