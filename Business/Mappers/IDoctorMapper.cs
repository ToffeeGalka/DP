using Business.Models;
using WebData.Entities;

namespace Business.Mappers
{
    public interface IDoctorMapper
    {
        Doctor MapToModel(DoctorEntity entity);
        DoctorEntity MapFromModel(Doctor doctor);
    }
}
