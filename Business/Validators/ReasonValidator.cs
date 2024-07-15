using Business.Models;

namespace Business.Validators
{
    public static class ReasonValidator
    {
        public static void Validate(Reason reason)
        {
            if (string.IsNullOrEmpty(reason.ReasonName))
                throw new Exception("REASON IS NOT BE NULL OR EMPTY");
        }
    }
}
