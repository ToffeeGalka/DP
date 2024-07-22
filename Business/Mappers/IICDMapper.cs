using Business.Models;
using WebData.Entities;

namespace Business.Mappers
{
    public interface IICDMapper
    {
        ICD10 MapToModel(ICDEntity entity);
        ICDEntity MapFromModel(ICD10 icd10);
    }
}
