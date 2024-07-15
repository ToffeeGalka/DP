using Business.Models;
using WebData.Entities;

namespace Business.Mappers
{
    public class DispRegMapper : IDispRegMapper
    {
        public DispReg MapToModel(DispRegEntity entity)
        {
            return new DispReg
            {
                Id = entity.Id,
                IdPatient = entity.IdPatient,
                PatientName = $"{entity.Patient.SecName} {entity.Patient.Name} {entity.Patient.SurName}",
                DateTaken = entity.DateTaken,
                IdICD = entity.IdICD,
                ICDCodeName = $"{entity.ICD.ICDCode} {entity.ICD.NameCode}",
                IdDoctor = entity.IdDoctor,
                DoctorName = $"{entity.Doctor.SecName} {entity.Doctor.Name} {entity.Doctor.SurName}",
                DateNotTaken = entity.DateNotTaken,
                IdReason = entity.IdReason,
                ReasonName = entity.Reason?.ReasonName
            };
        }
        public DispRegEntity MapFromModel(DispReg dispReg) 
        {
            return new DispRegEntity
            {
                Id = dispReg.Id,
                IdPatient = dispReg.IdPatient,
                DateTaken = dispReg.DateTaken,
                IdICD = dispReg.IdICD,
                IdDoctor = dispReg.IdDoctor,
                DateNotTaken = dispReg.DateNotTaken,
                IdReason = dispReg.IdReason
            };
        }
    }
}
