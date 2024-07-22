using Business.Models;
using WebData.Entities;

namespace Business.Services
{
    public interface IICDService
    {
        public ICDEntity[] GetAll();
        public Task<int> AddICD(ICD10 icdEntity);
        public Task EditICD(ICD10 icdEntity);
        public Task DeleteICD(int idICD);
    }
}
