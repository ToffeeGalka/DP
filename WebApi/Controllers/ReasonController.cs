using Business.Models;
using Business.Services;
using Microsoft.AspNetCore.Mvc;
using WebData.Entities;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReasonController(IReasonService reasonService) : ControllerBase
    {
        [HttpGet("GetReasonAll")]
        public ReasonEntity[] GetAll() => reasonService.GetAll();

        [HttpPost("AddReason")]
        public async Task AddReason(Reason reasonEntity) => await reasonService.AddReason(reasonEntity);

        [HttpPut("EditReason")]
        public async Task EditReason(Reason reason) => await reasonService.EditReason(reason);

        [HttpDelete("DeleteReason")]
        public async Task DeleteReason(int idReason) => await reasonService.DeleteReason(idReason);
    }
}
