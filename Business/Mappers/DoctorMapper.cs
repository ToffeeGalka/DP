using Business.Models;
using WebData.Entities;

namespace Business.Mappers
{
    public class DoctorMapper : IDoctorMapper
    {
        public Doctor MapToModel(DoctorEntity entity)
        {
            return new Doctor
            {
                Id = entity.Id,
                SecName = entity.SecName,
                Name = entity.Name,
                SurName = entity.SurName,
                IdPost = entity.IdPost,
                PostName = entity.Post?.PostName ?? ""
            };
        }
        public DoctorEntity MapFromModel(Doctor doctor) 
        {
            return new DoctorEntity
            {
                Id = doctor.Id,
                SecName = doctor.SecName,
                Name = doctor.Name,
                SurName = doctor.SurName,
                IdPost = doctor.IdPost
            };
        }
    }
}
