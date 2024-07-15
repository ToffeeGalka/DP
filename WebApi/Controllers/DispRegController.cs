using Business.Models;
using Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DispRegController(IDispRegService dispRegService) : ControllerBase
    {
        [HttpGet("GetDispRegAll")]
        public DispReg[] GetAll() => dispRegService.GetAll();

        [HttpPost("AddDispReg")]
        public async Task AddDispReg(DispReg dispRegEntity) => await dispRegService.AddDispReg(dispRegEntity);

        [HttpPut("EditDispReg")]
        public async Task EditDispReg(DispReg dispReg) => await dispRegService.EditDispReg(dispReg);

        [HttpDelete("DeleteDispReg")]
        public async Task DeleteDispReg(int idDispReg) => await dispRegService.DeleteDispReg(idDispReg);
    }
}
