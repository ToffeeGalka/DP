using Microsoft.EntityFrameworkCore;
using Business.Models;
using WebData.Entities;
using WebData;
using Business.Mappers;
using Business.Validators;

namespace Business.Services
{
    public class ICDService(AppDbContext dbContext, IICDMapper icdMapper) : IICDService
    {
        public ICDEntity[] GetAll()
        {
            var icd = dbContext.ICD10.ToArray();
            return icd;
        }
        public async Task<int> AddICD(ICD10 icd10)
        {
            ICDValidator.Validate(icd10);
            var entity = icdMapper.MapFromModel(icd10);
            dbContext.ICD10.Add(entity);
            await dbContext.SaveChangesAsync();
            return entity.Id;
        }
        public async Task EditICD(ICD10 icd10)
        {
            var oldEditICD = await dbContext.ICD10.FirstOrDefaultAsync(p => p.Id == icd10.Id);
            ICDValidator.Validate(icd10);
            var newValues = icdMapper.MapFromModel(icd10);
            dbContext.Entry(oldEditICD).CurrentValues.SetValues(newValues);
            await dbContext.SaveChangesAsync();
        }
        public async Task DeleteICD(int idICD)
        {
            var icdId = await dbContext.ICD10.FirstOrDefaultAsync(p => p.Id == idICD);
            if (icdId == null)
                return;
            dbContext.Remove(icdId);
            await dbContext.SaveChangesAsync();
        }
    }
}
