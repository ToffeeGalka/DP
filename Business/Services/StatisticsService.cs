using Business.Mappers;
using Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebData;
using WebData.Entities;
using WebData.Enums;

namespace Business.Services
{
    public class StatisticsService(AppDbContext dbContext, IDispRegMapper dispRegMapper) : IStatisticsService
    {
        public async Task<int> GetCountsPatients()
        {
            var countPatient = await dbContext.Patients.CountAsync();
            return countPatient;
        }
        public async Task<int> RegisteredDispPeriod(DateOnly sRegisteredDate, DateOnly poRegisteredDate, CancellationToken cancellationToken)
        {
            var periodCount = await dbContext.DispRegs.CountAsync(s => s.DateTaken >= sRegisteredDate && s.DateTaken <= poRegisteredDate, cancellationToken);
            return periodCount;
        }
        public DispReg[] RegisteredDispPeriodList(DateOnly sRegisteredDate, DateOnly poRegisteredDate)
        {
            var dispReg = dbContext.DispRegs.Include(p => p.Patient)
                                            .Include(p => p.ICD)
                                            .Include(p => p.Doctor)
                                            .Include(p => p.Reason)
                                            .Where(p => p.DateTaken >= sRegisteredDate && p.DateTaken <= poRegisteredDate)
                                            .ToArray().Select(p => dispRegMapper.MapToModel(p)).ToArray();
            return dispReg;
        }
        public async Task<int> UnRegisteredDispPeriod(DateOnly sUnRegisteredDate, DateOnly poUnRegisteredDate, CancellationToken cancellationToken)
        {
            var periodCount = await dbContext.DispRegs.CountAsync(s => s.DateNotTaken >= sUnRegisteredDate && s.DateNotTaken <= poUnRegisteredDate, cancellationToken);
            return periodCount;
        }
        public DispReg[] UnRegisteredDispPeriodList(DateOnly sUnRegisteredDate, DateOnly poUnRegisteredDate)
        {
            var dispReg = dbContext.DispRegs.Include(p => p.Patient)
                                                       .Include(p => p.ICD)
                                                       .Include(p => p.Doctor)
                                                       .Include(p => p.Reason)
                                                       .Where(p => p.DateNotTaken >= sUnRegisteredDate && p.DateNotTaken <= poUnRegisteredDate)
                                                       .ToArray().Select(p => dispRegMapper.MapToModel(p)).ToArray();
            return dispReg;
        }
        public async Task<int> DoctorRegisteredDispPeriod(DateOnly sRegisteredDate, DateOnly poRegisteredDate, int idDoctor, CancellationToken cancellationToken)
        {
            var periodCount =await dbContext.DispRegs.CountAsync(s => s.DateTaken >= sRegisteredDate && s.DateTaken <= poRegisteredDate && s.IdDoctor == idDoctor, cancellationToken);
            return periodCount;
        }
        public DispReg[] DoctorRegisteredDispPeriodListPatients(DateOnly sRegisteredDate, DateOnly poRegisteredDate, int idDoctor)
        {
            var dispReg = dbContext.DispRegs.Include(p => p.Patient)
                                                          .Include(p => p.ICD)
                                                          .Include(p => p.Doctor)
                                                          .Include(p => p.Reason)
                                                          .Where(p => p.DateTaken >= sRegisteredDate && p.DateTaken <= poRegisteredDate && p.IdDoctor == idDoctor)
                                                          .ToArray().Select(p => dispRegMapper.MapToModel(p)).ToArray();
            return dispReg;
        }
        public async Task<int> DoctorUnRegisteredDispPeriod(DateOnly sUnRegisteredDate, DateOnly poUnRegisteredDate, int idDoctor, CancellationToken cancellationToken)
        {
            var periodCount = await dbContext.DispRegs.CountAsync(s => s.DateNotTaken >= sUnRegisteredDate && s.DateNotTaken <= poUnRegisteredDate && s.IdDoctor == idDoctor, cancellationToken);
            return periodCount;
        }
        public DispReg[] DoctorUnRegisteredDispPeriodListPatients(DateOnly sUnRegisteredDate, DateOnly poUnRegisteredDate, int idDoctor)
        {
            var dispReg = dbContext.DispRegs.Include(p => p.Patient)
                                              .Include(p => p.ICD)
                                              .Include(p => p.Doctor)
                                              .Include(p => p.Reason)
                                              .Where(p => p.DateNotTaken >= sUnRegisteredDate && p.DateNotTaken <= poUnRegisteredDate && p.IdDoctor == idDoctor)
                                              .ToArray().Select(p => dispRegMapper.MapToModel(p)).ToArray();
            return dispReg;
        }
    }
}
