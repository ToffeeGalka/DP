
using Business.Models;
namespace Business.Services
{
    public interface IDoctorService
    {
        public Doctor[] GetAll();
        public Task<int> AddDoctor(Doctor doctorEntity);
        public Task EditDoctor(Doctor doctorEntity);
        public Task DeleteDoctor(int idDoctor);
    }
}
