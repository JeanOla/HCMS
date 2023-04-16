﻿using HCMS.Models;

namespace HCMS.Repository
{
    public interface IDoctorRepository
    {
        List<Speciality> populateSpeciality();

        List<ApplicationUser> getDoctors();

        ApplicationUser DeleteDoctor(string Id);
        List<ApplicationUser> getDoctorsInfo(string Id);
        ApplicationUser getDoctorById(string Id);

        List<ApplicationUser>getDoctorsExcept(string email);
    }
}
