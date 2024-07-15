using Business.Models;
using Business.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebData.Entities;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ICDController(IICDService icdService) : ControllerBase
    {
        [HttpGet("GetICDAll")]
        public ICDEntity[] GetAll() => icdService.GetAll();

        [HttpPost("AddICD")]
        public async Task AddICD(ICD10 icdEntity) => await icdService.AddICD(icdEntity);

        [HttpPut("EdiICD")]
        public async Task EditICD(ICD10 icd10) => await icdService.EditICD(icd10);

        [HttpDelete("DeleteICD")]
        public async Task DeleteICD(int idICD) => await icdService.DeleteICD(idICD);
    }
}
