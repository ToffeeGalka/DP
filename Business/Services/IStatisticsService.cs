using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebData.Entities;

namespace Business.Services
{
    public interface IStatisticsService
    {
        public Task<int> GetCountsPatients();
        public Task<int> RegisteredDispPeriod(DateOnly sRegisteredDate, DateOnly poRegisteredDate, CancellationToken cancellationToken);
        public DispReg[] RegisteredDispPeriodList(DateOnly sRegisteredDate, DateOnly poRegisteredDate);
        public Task<int> UnRegisteredDispPeriod(DateOnly sUnRegisteredDate, DateOnly poUnRegisteredDate, CancellationToken cancellationToken);
        public DispReg[] UnRegisteredDispPeriodList(DateOnly sUnRegisteredDate, DateOnly poUnRegisteredDate);
        public Task<int> DoctorRegisteredDispPeriod(DateOnly sRegisteredDate, DateOnly poRegisteredDate, int idDoctor, CancellationToken cancellationToken);
        public DispReg[] DoctorRegisteredDispPeriodListPatients(DateOnly sRegisteredDate, DateOnly poRegisteredDate, int idDoctor);
        public Task<int> DoctorUnRegisteredDispPeriod(DateOnly sUnRegisteredDate, DateOnly poUnRegisteredDate, int idDoctor, CancellationToken cancellationToken);
        public DispReg[] DoctorUnRegisteredDispPeriodListPatients(DateOnly sUnRegisteredDate, DateOnly poUnRegisteredDate, int idDoctor);

    }
}
