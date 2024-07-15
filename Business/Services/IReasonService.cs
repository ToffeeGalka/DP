using Business.Models;
using WebData.Entities;

namespace Business.Services
{
    public interface IReasonService
    {
        public ReasonEntity[] GetAll();
        public Task<int> AddReason(Reason reasonEntity);
        public Task EditReason(Reason reasonEntity);
        public Task DeleteReason(int idReason);
    }
}
