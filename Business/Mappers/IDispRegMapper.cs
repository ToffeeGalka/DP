using Business.Models;
using WebData.Entities;

namespace Business.Mappers
{
    public interface IDispRegMapper
    {
        DispReg MapToModel(DispRegEntity entity);
        DispRegEntity MapFromModel(DispReg dispReg);
    }
}
