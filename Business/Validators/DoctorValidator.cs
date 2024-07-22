using Business.Models;
using Microsoft.EntityFrameworkCore;
using WebData;

namespace Business.Validators;

public class DoctorValidator : IDoctorValidator
{
    public async Task Validate(Doctor doctor, AppDbContext dbContext)
    {
       
        if (string.IsNullOrEmpty(doctor.SurName))
            throw new Exception("SURNAME DOCTOR IS NOT BE NULL OR EMPTY");
        if (string.IsNullOrEmpty(doctor.Name))
            throw new Exception("NAME DOCTOR IS NOT BE NULL OR EMPTY");
        if (!await dbContext.Posts.AnyAsync(p => p.Id == doctor.IdPost))
            throw new Exception("POST NOT FOUND");
    }
}
