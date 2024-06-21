using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using Business.Models;
using Business.Services;
using WebData.Entities;
using WebData;

namespace Business.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PatientController(AppDbContext dbContext, IPatientService patientService) : ControllerBase
    {
        [HttpGet("GetPatient")]
        public PatientEntity[] Get() 
        {
            var patients = dbContext.Patients.ToArray();
            return patients;
        }
        [HttpGet ("{id}")]
        public async Task<ActionResult<PatientEntity>> Get(int id) 
        {
            var patients = await dbContext.Patients.FirstOrDefaultAsync(x => x.Id == id);
            if (patients == null)
            return NotFound();
            return new ObjectResult(patients);
        }

        [HttpPost("AddPatient")]
        public async Task AddPatient(PatientEntity patientEntity) => await patientService.AddPatient(patientEntity);
            
        [HttpPut("EditPatient")]
        public async Task EditPatient(Patient patient) => await patientService.EditPatient(patient);

        [HttpDelete("DeletePatient")]
        public async Task DeletePatient(int idPatient) => await patientService.DeletePatient(idPatient);   
    }
}
