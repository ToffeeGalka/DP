using Business.Models;

namespace Business.Validators
{
    public class ReasonValidator : IReasonValidator
    {
        public void Validate(Reason reason)
        {
            if (string.IsNullOrEmpty(reason.ReasonName))
                throw new Exception("REASON IS NOT BE NULL OR EMPTY");
        }
    }
}
