
using WebApi.Models;
using WebData.Entities;
namespace WebApi.Services
{
    public interface IPatientService
    {
        public Task AddPatient(PatientEntity patientEntity);
        public Task EditPatient(PatientEntity patientEntity);
        public Task DeletePatient(int idPatient);
    }
}
