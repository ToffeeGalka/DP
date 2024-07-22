using Business.Models;
using WebData.Entities;

namespace Business.Mappers
{
    public class ICDMapper : IICDMapper
    {
        public ICD10 MapToModel(ICDEntity entity)
        {
            return new ICD10
            {
                Id = entity.Id,
                ParentId = entity.ParentId,
                ICDCode = entity.ICDCode,
                NameCode = entity.NameCode
            };
        }
        public ICDEntity MapFromModel(ICD10 icd10)
        {
            return new ICDEntity
            {
                Id = icd10.Id,
                ParentId = icd10.ParentId,
                ICDCode = icd10.ICDCode,
                NameCode = icd10.NameCode
            };
        }
    }
}
