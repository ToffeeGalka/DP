using Business.Models;

namespace Business.Validators;

public static class DoctorValidator
{
    public static void Validate(Doctor doctor)
    {
        if (string.IsNullOrEmpty(doctor.SurName))
            throw new Exception("SURNAME DOCTOR IS NOT BE NULL OR EMPTY");
        if (string.IsNullOrEmpty(doctor.Name))
            throw new Exception("NAME DOCTOR IS NOT BE NULL OR EMPTY");
    }
}
