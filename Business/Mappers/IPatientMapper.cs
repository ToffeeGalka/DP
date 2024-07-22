using Business.Models;
using WebData.Entities;

namespace Business.Mappers
{
    public interface IPatientMapper
    {
        Patient MapToModel(PatientEntity entity);
        PatientEntity MapFromModel(Patient patient);
    }
}
