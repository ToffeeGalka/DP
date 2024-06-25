namespace Business.Models
{
    public class ICD10
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string ICDCode { get; set; }
        public string NameCode { get; set; }
    }
}
