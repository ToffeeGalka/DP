
using WebApi.Models;
using WebData.Entities;
namespace WebApi.Services
{
    public interface IPatientService
    {
        public Task AddPatient(string surName, string name, string secName, DateOnly dateOfBirth, string sex, string address, string phone);
    }
}
