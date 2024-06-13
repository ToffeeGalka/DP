using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Services;
using WebData;
using WebData.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController(AppDbContext dbContext, IPatientService patientService) : ControllerBase
    {
        [HttpGet("GetPatient")]
        public PatientEntity[] Get() 
        {
            var patients = dbContext.Patients.ToArray();
            return patients;
        }
    }
}
