using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using WebApi.Models;
using WebApi.Services;
using WebData;
using WebData.Entities;

namespace WebApi.Controllers
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
        public async Task<ActionResult<PatientEntity>> AddPatient(PatientEntity patientEntity) 
        {
            if ((patientEntity.Sex != "м") & (patientEntity.Sex != "ж"))
            {
                ModelState.AddModelError("Sex", "Ввдеите 'м' или 'ж'");
            }
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);
            await patientService.AddPatient(patientEntity);
            return Ok(patientEntity);

        }
            
        [HttpPut("EditPatient")]
        public async Task EditPatient(PatientEntity patient) => await patientService.EditPatient(patient);

        [HttpDelete("DeletePatient")]
        public async Task DeletePatient(int idPatient) => await patientService.DeletePatient(idPatient);   
    }
}
