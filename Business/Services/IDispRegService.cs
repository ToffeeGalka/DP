
using Business.Models;
namespace Business.Services
{
    public interface IDispRegService
    {
        public DispReg[] GetAll();
        public Task<int> AddDispReg(DispReg dispRegEntity);
        public Task EditDispReg(DispReg dispRegEntity);
        public Task DeleteDispReg(int idDispReg);
    }
}
