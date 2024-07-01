
using Business.Models;
using WebData.Entities;
namespace Business.Services
{
    public interface IPatientService
    {
        public PatientEntity[] GetAll();
        public Task<PatientEntity> Get(int id);
        public Task<int> AddPatient(Patient patientEntity);
        public Task EditPatient(Patient patientEntity);
        public Task DeletePatient(int idPatient);
    }
}
