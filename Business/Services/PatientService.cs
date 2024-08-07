﻿using Microsoft.EntityFrameworkCore;
using Business.Models;
using WebData.Entities;
using WebData;
using Business.Mappers;
using Business.Validators;

namespace Business.Services
{
    public class PatientService(AppDbContext context, IPatientMapper mapper, IPatientValidator patientValidator) : IPatientService
    {

        public PatientEntity[] GetAll()
        {
            var patients = context.Patients.ToArray();
            return patients;
        }
        public async Task<PatientEntity> Get(int id)
        {
            var patients = await context.Patients.FirstOrDefaultAsync(x => x.Id == id);
            if (patients == null)
            {
                throw new Exception("Пациент не найден!");
            }
            return patients;
        }
        public async Task<int> AddPatient(Patient patient)
            {
            patientValidator.Validate(patient);
            var entity = mapper.MapFromModel(patient);
            context.Patients.Add(entity);
            await context.SaveChangesAsync();
            return entity.Id;
            }
        public async Task EditPatient(Patient patient)
        {
            var oldEditPatient = await context.Patients.FirstOrDefaultAsync(p => p.Id == patient.Id);
            if (oldEditPatient == null)
            {
                throw new Exception("ID PATIENT NOT FOUND");
            }
            patientValidator.Validate(patient);
            var newValues = mapper.MapFromModel(patient);
            context.Entry(oldEditPatient).CurrentValues.SetValues(newValues);
            await context.SaveChangesAsync();
        }
        public async Task DeletePatient(int idPatient)
        {
            var patientId = await context.Patients.FirstOrDefaultAsync(p=>p.Id == idPatient);
            if (patientId == null)
            {
                throw new Exception("ID PATIENT NOT FOUND");
            }
            context.Remove(patientId);
            await context.SaveChangesAsync();
        }

        

    }
}
