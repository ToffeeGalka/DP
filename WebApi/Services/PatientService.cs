using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using WebData;
using Microsoft.EntityFrameworkCore;
using WebData.Entities;

namespace WebApi.Services
{
    public class PatientService(AppDbContext context) : IPatientService
    {
        public async Task AddPatient(string surName, string name, string secName, DateOnly dateOfBirth, string sex, string address, string phone)
            { 
            context.Add(new PatientEntity
                { 
                SurName = surName,
                Name = name,
                SecName = secName,
                DateOfBirth = dateOfBirth,
                Sex = sex,
                Address = address,
                Phone = phone,              
                });
            await context.SaveChangesAsync();
            }
    }
}
