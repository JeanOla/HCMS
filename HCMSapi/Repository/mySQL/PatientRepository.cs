using HCMSapi.data;
using HCMSapi.Models;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HCMSapi.Repository.mySQL
{
    public class PatientAndMedicalRecord
    {
        public Patient Patient { get; set; }
        public MedicalRecord MedicalRecord { get; set; }
    }
    public class PatientRepository : IPatientRepository
    {
        HCMSDbContext _dbContext;


        public PatientRepository(HCMSDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Patient> getPatients()
        {
            return _dbContext.patients.AsNoTracking().ToList();
        }
        public Patient GetPatienById(int Id)
        {
            return _dbContext.patients.Include(md => md.medical).AsNoTracking().ToList().FirstOrDefault(emp => emp.Id == Id);
        }
        public PatientAndMedicalRecord AddPatientAndMedicalRecord(Patient newPatient, MedicalRecord medred)
        {
            /*using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    _dbContext.patients.Add(newPatient);
                    _dbContext.SaveChanges();
                    medred = new MedicalRecord
                    {
                        patientId = newPatient.Id,
                        allergy = newPatient.medical.allergy,
                        medication = newPatient.medical.medication,
                        bloodType = newPatient.medical.bloodType,
                        diabetic = newPatient.medical.diabetic,
                        surgery = newPatient.medical.surgery,
                        vacinated = newPatient.medical.vacinated,
                    };
                    //medred.patientId = newPatient.Id; 
                    //_dbContext.medicalRecords.Add(medred);
                    _dbContext.SaveChanges();
                    transaction.Commit();

                    return new PatientAndMedicalRecord
                    {
                        Patient = newPatient,
                        MedicalRecord = medred
                    };

                }
                catch (Exception ex)
                {
                    transaction.Rollback();

                }
            }

            return null;*/

            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    _dbContext.patients.Add(newPatient);
                    _dbContext.SaveChanges();

                    medred.patientId = newPatient.Id;
                    _dbContext.medicalRecords.Add(medred);
                    _dbContext.SaveChanges();

                    transaction.Commit();

                    return new PatientAndMedicalRecord
                    {
                        Patient = newPatient,
                        MedicalRecord = medred
                    };
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    // Log the exception here if necessary
                }
            }

            return null;
        }

        public PatientAndMedicalRecord editPatient(Patient newPatient, MedicalRecord medred)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var patient = GetPatienById(newPatient.Id);
                    patient.firstName = newPatient.firstName;
                    patient.lastName = newPatient.lastName;
                    patient.middleName = newPatient.middleName;
                    patient.Email = newPatient.Email;
                    patient.address = newPatient.address;
                    patient.phone = newPatient.phone;
                    patient.gender = newPatient.gender;
                    patient.dob = newPatient.dob;
                    _dbContext.patients.Attach(patient);
                    _dbContext.Update(patient);
                    _dbContext.SaveChanges();

                    medred = patient.medical;
                    medred.allergy = newPatient.medical.allergy;
                    medred.medication = newPatient.medical.medication;
                    medred.bloodType = newPatient.medical.bloodType;
                    medred.diabetic = newPatient.medical.diabetic;
                    medred.surgery = newPatient.medical.surgery;
                    medred.vacinated = newPatient.medical.vacinated;
                    _dbContext.medicalRecords.Attach(medred);
                    _dbContext.Update(medred);
                    _dbContext.SaveChanges();
                    transaction.Commit();


                    return new PatientAndMedicalRecord
                    {
                        Patient = newPatient,
                        MedicalRecord = medred
                    };
                }
                catch (Exception ex)
                {
                    transaction.Rollback();

                }
            }

            return null;
        }

        public Patient DeletePatient(int Id)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var del = GetPatienById(Id);
                    if (del != null)
                    {
                        _dbContext.medicalRecords.Remove(del.medical);
                        _dbContext.patients.Remove(del);
                        _dbContext.SaveChanges();
                    }

                    transaction.Commit();
                    return del;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();

                }
            }
            return null;
        }
    }
}