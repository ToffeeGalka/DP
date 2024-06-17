using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using WebData;
using Microsoft.EntityFrameworkCore;
using WebData.Entities;
using Microsoft.AspNetCore.Http.HttpResults;

namespace WebApi.Services
{
    public class PatientService(AppDbContext context) : IPatientService
    {
        public async Task AddPatient(PatientEntity patientEntity)
            {
            context.Patients.Add(patientEntity);
            await context.SaveChangesAsync();
            }
        public async Task EditPatient(PatientEntity patient)
        {
            var oldEditPatient = await context.Patients.FirstOrDefaultAsync(p => p.Id == patient.Id);
            if (oldEditPatient == null)
                return;
            oldEditPatient.SurName = patient.SurName;
            oldEditPatient.Name = patient.Name;
            oldEditPatient.SecName = patient.SecName;
            oldEditPatient.DateOfBirth = patient.DateOfBirth;
            oldEditPatient.Sex = patient.Sex;
            oldEditPatient.Address = patient.Address;
            oldEditPatient.Phone = patient.Phone;
            await context.SaveChangesAsync();
        }
        public async Task DeletePatient(int idPatient)
        {
            var patientId = await context.Patients.FirstOrDefaultAsync(p=>p.Id == idPatient);
            if (patientId == null)       
                return;
            context.Remove(patientId);
            await context.SaveChangesAsync();
        }

        

    }
}
