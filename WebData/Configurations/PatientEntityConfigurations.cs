using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebData.Entities;

namespace WebData.Configurations
{
    internal class PatientEntityConfigurations : IEntityTypeConfiguration<PatientEntity>
    {
        public void Configure(EntityTypeBuilder<PatientEntity> builder)
        { 
            builder.HasKey(x => x.Id);
            builder.Property(x => x.SurName).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.SecName).HasMaxLength(255);
            builder.Property(x => x.Sex).IsRequired().HasMaxLength(255);
            builder.Property(x => x.DateOfBirth).IsRequired();            
            builder.Property(x => x.Address).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Phone).HasMaxLength(255);
        }
    }
}
