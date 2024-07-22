using Microsoft.EntityFrameworkCore;
using Business.Models;
using WebData;
using Business.Mappers;
using Business.Validators;

namespace Business.Services
{
    public class DispRegService(AppDbContext dbContext, IDispRegMapper dispRegMapper, IDispRegValidator dispRegValidator) : IDispRegService
    {
        public DispReg[] GetAll()
        {
            var dispReg = dbContext.DispRegs.Include(p => p.Patient)
                .Include(p => p.ICD)
                .Include(p => p.Doctor)
                .Include(p => p.Reason)
                .ToArray().Select(p => dispRegMapper.MapToModel(p)).ToArray();

            return dispReg;
        }
        public async Task<int> AddDispReg(DispReg dispReg)
        {
            await dispRegValidator.Validate(dispReg, dbContext);
            var entity = dispRegMapper.MapFromModel(dispReg);
            dbContext.DispRegs.Add(entity);
            await dbContext.SaveChangesAsync();
            return entity.Id;
        }
        public async Task EditDispReg(DispReg dispReg)
        {
            var oldEditDispReg = await dbContext.DispRegs.FirstOrDefaultAsync(p => p.Id == dispReg.Id);
            if (oldEditDispReg == null)
            {
                throw new Exception("ID DISPREG NOT FOUND");
            }
            await dispRegValidator.Validate(dispReg, dbContext);
            var newValues = dispRegMapper.MapFromModel(dispReg);
            dbContext.Entry(oldEditDispReg).CurrentValues.SetValues(newValues);
            await dbContext.SaveChangesAsync();
        }
        public async Task DeleteDispReg(int idDispReg)
        {
            var dispRegId = await dbContext.DispRegs.FirstOrDefaultAsync(p => p.Id == idDispReg);
            if (dispRegId == null)
            { 
                throw new Exception("ID DISPREG NOT FOUND"); 
            }
            dbContext.Remove(dispRegId);
            await dbContext.SaveChangesAsync();
        }
    }
}
