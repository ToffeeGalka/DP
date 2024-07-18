using Microsoft.EntityFrameworkCore;
using Business.Models;
using WebData;
using Business.Mappers;
using Business.Validators;

namespace Business.Services
{
    public class DoctorService(AppDbContext dbContext, IDoctorMapper doctorMapper, IDoctorValidator doctorValidator) : IDoctorService
    {
        public Doctor[] GetAll()
        {
            var doctor = dbContext.Doctors.Include(p => p.Post).ToArray().Select(p => doctorMapper.MapToModel(p)).ToArray();
            return doctor;
        }
        public async Task<int> AddDoctor(Doctor doctor)
        {
            await doctorValidator.Validate(doctor, dbContext);
            var entity = doctorMapper.MapFromModel(doctor);
            dbContext.Doctors.Add(entity);
            await dbContext.SaveChangesAsync();
            return entity.Id;
        }
        public async Task EditDoctor(Doctor doctor)
        {
            var oldEditDoctor = await dbContext.Doctors.FirstOrDefaultAsync(p => p.Id == doctor.Id);
            if (oldEditDoctor == null) 
            { 
                throw new Exception("ID DOCTOR NOT FOUND"); 
            }
            await doctorValidator.Validate(doctor, dbContext);
            var newValues = doctorMapper.MapFromModel(doctor);
            dbContext.Entry(oldEditDoctor).CurrentValues.SetValues(newValues);
            await dbContext.SaveChangesAsync();
        }
        public async Task DeleteDoctor(int idDoctor)
        {
            var doctorId = await dbContext.Doctors.FirstOrDefaultAsync(p => p.Id == idDoctor);
            if (doctorId == null)
            {
                throw new Exception("ID DOCTOR NOT FOUND");
            }
            dbContext.Remove(doctorId);
            await dbContext.SaveChangesAsync();
        }
    }
}
