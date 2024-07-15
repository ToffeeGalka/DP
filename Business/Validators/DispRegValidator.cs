using Business.Models;

namespace Business.Validators;

public static class DispRegValidator
{
    public static void Validate(DispReg dispReg)
    {
        if (dispReg.DateTaken > DateOnly.FromDateTime(DateTime.Today))
            throw new Exception("DATE TAKEN CANNOT BE LONGER THAN CURRENT DATE");
        if (dispReg.DateNotTaken > DateOnly.FromDateTime(DateTime.Today))
            throw new Exception("DATE NOT TAKEN CANNOT BE LONGER THAN CURRENT DATE");
    }

}
