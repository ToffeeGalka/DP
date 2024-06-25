﻿using Microsoft.EntityFrameworkCore;
using Business.Models;
using Microsoft.EntityFrameworkCore;
using WebData.Entities;
using WebData;
using Business.Mappers;
using System.Data;

namespace Business.Services
{
    public class PatientService(AppDbContext context, IPatientMapper mapper) : IPatientService
    {
        public async Task<PatientEntity> Get(int id)
        {
            var patients = await context.Patients.FirstOrDefaultAsync(x => x.Id == id);
            if (patients == null)
            {
                throw new Exception("Пациент не найден!");
            }
            return patients;
        }
        public async Task<int> AddPatient(PatientEntity patientEntity)
            {
            if ((patientEntity.Sex != "м") & (patientEntity.Sex != "ж"))
            {
             throw new Exception("Пол не корректный!!! Ввдеите 'м' или 'ж'");
            }
            context.Patients.Add(patientEntity);
            await context.SaveChangesAsync();
            return patientEntity.Id;
            }
        public async Task EditPatient(Patient patient)
        {
            var oldEditPatient = await context.Patients.FirstOrDefaultAsync(p => p.Id == patient.Id);
            var newValues = mapper.MapFromModel(patient);
            context.Entry(oldEditPatient).CurrentValues.SetValues(newValues);
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
