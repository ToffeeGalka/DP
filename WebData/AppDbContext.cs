using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebData.Entities;
namespace WebData
{
    public class AppDbContext : DbContext
    {
        public DbSet<PatientEntity> Patients { get; set; }
        public DbSet<PostEntity> Posts { get; set; }
        public DbSet<ReasonEntity> Reasons { get; set; }
        public DbSet<ICDEntity> ICD10 { get; set; }
        public DbSet<DoctorEntity> Doctors { get; set; }    
        public DbSet<DispRegEntity> DispRegs { get; set; }
        public AppDbContext()
        {
        }
        public AppDbContext(DbContextOptions options) : base(options) 
        { 
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
