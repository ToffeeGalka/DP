using Business.Models;
using Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DoctorController(IDoctorService doctorService) : ControllerBase
    {
        [HttpGet("GetDoctorAll")]
        public Doctor[] GetAll() => doctorService.GetAll();

        [HttpPost("AddDoctor")]
        public async Task AddDoctor(Doctor doctorEntity) => await doctorService.AddDoctor(doctorEntity);

        [HttpPut("EditDoctor")]
        public async Task EditDoctor(Doctor doctor) => await doctorService.EditDoctor(doctor);

        [HttpDelete("DeleteDoctor")]
        public async Task DeleteDoctor(int idDoctor) => await doctorService.DeleteDoctor(idDoctor);
    }
}
