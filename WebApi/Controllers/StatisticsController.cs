using Microsoft.AspNetCore.Mvc;
using Business.Models;
using Business.Services;
using WebData.Entities;

namespace Business.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StatisticsController(IStatisticsService statisticsService) : ControllerBase
    {
        [HttpGet("CountPatient")]
        public async Task<int> GetCountsPatient() => await statisticsService.GetCountsPatients();
        
        [HttpGet("CountRegisteredDispPeriod")]
        public async Task<int> RegisteredDispPeriod(DateOnly sRegisteredDate, DateOnly poRegisteredDate, CancellationToken cancellationToken) => await statisticsService.RegisteredDispPeriod(sRegisteredDate, poRegisteredDate, cancellationToken);
       
        [HttpGet("RegisteredDispPeriodList")]
        public DispReg[] RegisteredDispPeriodList(DateOnly sRegisteredDate, DateOnly poRegisteredDate) => statisticsService.RegisteredDispPeriodList(sRegisteredDate, poRegisteredDate);

        [HttpGet("CountUnRegisteredDispPeriod")]
        public async Task<int> UnRegisteredDispPeriod(DateOnly sUnRegisteredDate, DateOnly poUnRegisteredDate, CancellationToken cancellationToken) => await statisticsService.UnRegisteredDispPeriod(sUnRegisteredDate, poUnRegisteredDate, cancellationToken);

        [HttpGet("UnRegisteredDispPeriodList")]
        public DispReg[] UnRegisteredDispPeriodList(DateOnly sUnRegisteredDate, DateOnly poUnRegisteredDate) => statisticsService.UnRegisteredDispPeriodList(sUnRegisteredDate, poUnRegisteredDate);

        [HttpGet("CountDoctorRegisteredDispPeriod")]
        public async Task<int> DoctorRegisteredDispPeriod(DateOnly sRegisteredDate, DateOnly poRegisteredDate, int idDoctor, CancellationToken cancellationToken) 
            => await statisticsService.DoctorRegisteredDispPeriod(sRegisteredDate, poRegisteredDate, idDoctor, cancellationToken);

        [HttpGet("DoctorRegisteredDispPeriodListPatients")]
        public DispReg[] DoctorRegisteredDispPeriodListPatients(DateOnly sRegisteredDate, DateOnly poRegisteredDate, int idDoctor)
            => statisticsService.DoctorRegisteredDispPeriodListPatients(sRegisteredDate, poRegisteredDate, idDoctor);

        [HttpGet("CountDoctorUnRegisteredDispPeriod")]
        public async Task<int> DoctorUnRegisteredDispPeriod(DateOnly sUnRegisteredDate, DateOnly poUnRegisteredDate, int idDoctor, CancellationToken cancellationToken) 
            => await statisticsService.DoctorUnRegisteredDispPeriod(sUnRegisteredDate, poUnRegisteredDate, idDoctor, cancellationToken);

        [HttpGet("DoctorUnRegisteredDispPeriodListPatients")]
        public DispReg[] DoctorUnRegisteredDispPeriodListPatients(DateOnly sUnRegisteredDate, DateOnly poUnRegisteredDate, int idDoctor)
            => statisticsService.DoctorUnRegisteredDispPeriodListPatients(sUnRegisteredDate, poUnRegisteredDate, idDoctor);


    }
}
