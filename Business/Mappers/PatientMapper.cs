using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebData.Entities;
using WebData.Enums;

namespace Business.Mappers
{
    public class PatientMapper: IPatientMapper
    {
        public Patient MapToModel(PatientEntity entity)
        {
            return new Patient
            {
                Id = entity.Id,
                SurName = entity.SurName,
                Name = entity.Name,
                SecName = entity.SecName,
                DateOfBirth = entity.DateOfBirth,
                Sex = entity.Sex.GetSexName(),
                Address = entity.Address,
                Phone = entity.Phone              
            };
        }
        public PatientEntity MapFromModel(Patient patient)
        {
            if (patient.Sex != "ж" && patient.Sex != "м")
                throw new Exception("Sex is not defined correctly");
            return new PatientEntity
            {
                Id = patient.Id,
                SurName = patient.SurName,
                Name = patient.Name,
                SecName = patient.SecName,
                DateOfBirth = patient.DateOfBirth,
                Sex = patient.Sex == "м" ? Sex.Male : Sex.Female,
                Address = patient.Address,
                Phone = patient.Phone
            };
        }

    }
}
