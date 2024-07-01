using WebData.Enums;

namespace WebData.Entities
{
    public class PatientEntity
    {
        public int Id { get; set; }
        public string SurName { get; set; }
        public string Name { get; set; }
        public string? SecName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public Sex Sex { get; set; }
        public string Address { get; set; }
        public string? Phone { get; set; }
    }
}
