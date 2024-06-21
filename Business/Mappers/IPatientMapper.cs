using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebData.Entities;

namespace Business.Mappers
{
    public interface IPatientMapper
    {
        Patient MapToModel(PatientEntity entity);
        PatientEntity MapFromModel(Patient patient);
    }
}
