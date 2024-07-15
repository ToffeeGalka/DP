using Business.Models;

namespace Business.Validators
{
    public static class ICDValidator
    {
        public static void Validate(ICD10 icd10)
        {
            if (string.IsNullOrEmpty(icd10.ICDCode))
                throw new Exception("ICD-CODE IS NOT BE NULL OR EMPTY");
            if(string.IsNullOrEmpty(icd10.NameCode))
                throw new Exception("NAME ICD-CODE IS NOT BE NULL OR EMPTY");
        }
    }
}
