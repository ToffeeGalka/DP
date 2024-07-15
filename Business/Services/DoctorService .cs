using Microsoft.EntityFrameworkCore;
using Business.Models;
using WebData;
using Business.Mappers;
using Business.Validators;

namespace Business.Services
{
    public class DoctorService(AppDbContext dbContext, IDoctorMapper doctorMapper) : IDoctorService
    {
        public Doctor[] GetAll()
        {
            var doctor = dbContext.Doctors.Include(p => p.Post).ToArray().Select(p => doctorMapper.MapToModel(p)).ToArray();
            return doctor;
        }
        public async Task<int> AddDoctor(Doctor doctor)
        {
            DoctorValidator.Validate(doctor);
            var entity = doctorMapper.MapFromModel(doctor);
            dbContext.Doctors.Add(entity);
            await dbContext.SaveChangesAsync();
            return entity.Id;
        }
        public async Task EditDoctor(Doctor doctor)
        {
            var oldEditDoctor = await dbContext.Doctors.FirstOrDefaultAsync(p => p.Id == doctor.Id);
            DoctorValidator.Validate(doctor);
            var newValues = doctorMapper.MapFromModel(doctor);
            dbContext.Entry(oldEditDoctor).CurrentValues.SetValues(newValues);
            await dbContext.SaveChangesAsync();
        }
        public async Task DeleteDoctor(int idDoctor)
        {
            var doctorId = await dbContext.Doctors.FirstOrDefaultAsync(p => p.Id == idDoctor);
            if (doctorId == null)
                return;
            dbContext.Remove(doctorId);
            await dbContext.SaveChangesAsync();
        }
    }
}
