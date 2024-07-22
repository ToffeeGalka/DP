using Microsoft.AspNetCore.Mvc;
using Business.Models;
using Business.Services;
using WebData.Entities;

namespace Business.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PatientController(IPatientService patientService) : ControllerBase
    {
        [HttpGet("GetPatientAll")]
        public PatientEntity[] GetAll() => patientService.GetAll();

        [HttpGet ("GetPatient {id}")]
        public async Task<PatientEntity> Get(int id) => await patientService.Get(id);

        [HttpPost("AddPatient")]
        public async Task AddPatient(Patient patientEntity) => await patientService.AddPatient(patientEntity);
            
        [HttpPut("EditPatient")]
        public async Task EditPatient(Patient patient) => await patientService.EditPatient(patient);

        [HttpDelete("DeletePatient")]
        public async Task DeletePatient(int idPatient) => await patientService.DeletePatient(idPatient);   
    }
}
