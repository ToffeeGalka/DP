namespace WebData.Enums
{
    public enum Sex
    {
        Male,
        Female
    }
    public static class SexExtensions
    {
        public static string GetSexName(this Sex value)
        {
            return value switch
            {
                Sex.Female => "ж",
                Sex.Male => "м",
                _ => ""
            };
        }
    }
}
