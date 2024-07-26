using WebData.Enums;

namespace WebData.Entities
{
    public class PatientEntity
    {
        public int Id { get; set; }
        public string SurName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? SecName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public Sex Sex { get; set; }
        public string Address { get; set; } = string.Empty;
        public string? Phone { get; set; }
    }
}
