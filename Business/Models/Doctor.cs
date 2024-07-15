namespace Business.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string SurName { get; set; }
        public string Name { get; set; }
        public string? SecName { get; set; }
        public int IdPost { get; set; }
        public string PostName { get; set;}
    }
}
