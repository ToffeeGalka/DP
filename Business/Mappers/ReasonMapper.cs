using Business.Models;
using WebData.Entities;

namespace Business.Mappers
{
    public class ReasonMapper : IReasonMapper
    {
        public Reason MapToModel(ReasonEntity entity)
        {
            return new Reason
            {
                Id = entity.Id,
                ReasonName = entity.ReasonName
            };
        }
        public ReasonEntity MapFromModel(Reason reason) 
        {
            return new ReasonEntity
            {
                Id = reason.Id,
                ReasonName = reason.ReasonName
            };
        }
    }
}
