﻿using HCMSapi.Models;

namespace HCMSapi.Repository
{
    public interface ICaseRepository
    {
        List<Patient> GetPatients();
        Cases addCase(Cases cases);

        List<Cases> getCases();
        Cases GetCaseById(int id);
        Cases updateCase(Cases casee);
        Cases DeleteCase(int Id);
    }
}
