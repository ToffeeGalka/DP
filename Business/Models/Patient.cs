using WebData.Enums;

namespace Business.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string SurName { get; set; }
        public string Name { get; set; }
        public string? SecName { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public  string Sex { get; set; }
        public string Address { get; set; }
        public string? Phone { get; set; }
    }
}
