using Business.Models;

namespace Business.Validators;

public static class PatientValidator
{
    public static void Validate(Patient patient)
    {
        if (string.IsNullOrEmpty(patient.SurName))
            throw new Exception("SURNAME PATIENT IS NOT BE NULL OR EMPTY");
        if (string.IsNullOrEmpty(patient.Name))
            throw new Exception("NAME PATIENT IS NOT BE NULL OR EMPTY");
        if (patient.DateOfBirth > DateOnly.FromDateTime(DateTime.Today))
            throw new Exception("DATE OF BIRTH CANNOT BE LONGER THAN CURRENT DATE");
        if (patient.Sex != "ж" && patient.Sex != "м")
            throw new Exception("GENDER PATIENT IS NOT CORRECT! INPUT 'м' OR 'ж'!");
        if (string.IsNullOrEmpty(patient.Address))
            throw new Exception("ADDRESS PATIENT IS NOT BE NULL OR EMPTY");
    }

}
