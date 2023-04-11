using HCMSapi.Models;
using HCMSapi.Repository.mySQL;

namespace HCMSapi.Repository
{
    public interface IPatientRepository
    {
        public List<Patient> getPatients();
        public Patient GetPatienById(int Id);
        PatientAndMedicalRecord AddPatientAndMedicalRecord(Patient newPatient, MedicalRecord medred);
        // Patient editPatient(int Id, Patient patient);
        // PatientAndMedicalRecord UpdatePatientAndMedicalRecord(Patient newPatient, MedicalRecord medred);
        PatientAndMedicalRecord editPatient(Patient newPatient, MedicalRecord medred);

        Patient DeletePatient(int Id);
    }
}
