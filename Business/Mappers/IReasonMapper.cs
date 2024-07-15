using Business.Models;
using WebData.Entities;

namespace Business.Mappers
{
    public interface IReasonMapper
    {
        Reason MapToModel(ReasonEntity entity);
        ReasonEntity MapFromModel(Reason reason);
    }
}
