using Microsoft.EntityFrameworkCore;
using Business.Models;
using WebData.Entities;
using WebData;
using Business.Mappers;
using Business.Validators;

namespace Business.Services
{
    public class ReasonService(AppDbContext dbContext, IReasonMapper reasonMapper, IReasonValidator reasonValidator) : IReasonService
    {
        public ReasonEntity[] GetAll()
        {
            var reason = dbContext.Reasons.ToArray();
            return reason;
        }
        public async Task<int> AddReason(Reason reason)
        {
            await reasonValidator.Validate(reason);
            var entity = reasonMapper.MapFromModel(reason);
            dbContext.Reasons.Add(entity);
            await dbContext.SaveChangesAsync();
            return entity.Id;
        }
        public async Task EditReason(Reason reason)
        {
            var oldEditReason = await dbContext.Reasons.FirstOrDefaultAsync(p => p.Id == reason.Id);
            if (oldEditReason == null)
            {
                throw new Exception("ID REASON NOT FOUND");
            }
            await reasonValidator.Validate(reason);
            var newValues = reasonMapper.MapFromModel(reason);
            dbContext.Entry(oldEditReason).CurrentValues.SetValues(newValues);
            await dbContext.SaveChangesAsync();
        }
        public async Task DeleteReason(int idReason)
        {
            var reasonId = await dbContext.Reasons.FirstOrDefaultAsync(p => p.Id == idReason);
            if (reasonId == null)
            {
                throw new Exception("ID REASON NOT FOUND");
            }
            dbContext.Remove(reasonId);
            await dbContext.SaveChangesAsync();
        }
    }
}
