using Business.Models;
using Microsoft.EntityFrameworkCore;
using WebData;

namespace Business.Validators;

public class DispRegValidator : IDispRegValidator
{
    public async Task Validate(DispReg dispReg, AppDbContext dbContext)
    {
        if (!await dbContext.Patients.AnyAsync(p=> p.Id == dispReg.IdPatient))
            throw new Exception("PATIENT NOT FOUND");
        if (!await dbContext.ICD10.AnyAsync(p => p.Id == dispReg.IdICD))
            throw new Exception("ICD NOT FOUND");
        if (!await dbContext.Doctors.AnyAsync(p => p.Id == dispReg.IdDoctor))
            throw new Exception("DOCTOR NOT FOUND");
        if (!await dbContext.Reasons.AnyAsync(p => p.Id == dispReg.IdReason))
            throw new Exception("REASON NOT FOUND");
        if (dispReg.DateTaken > DateOnly.FromDateTime(DateTime.Today))
            throw new Exception("DATE TAKEN CANNOT BE LONGER THAN CURRENT DATE");
        if (dispReg.DateNotTaken > DateOnly.FromDateTime(DateTime.Today))
            throw new Exception("DATE NOT TAKEN CANNOT BE LONGER THAN CURRENT DATE");
    }

}
