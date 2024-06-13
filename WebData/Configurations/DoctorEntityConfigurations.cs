using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebData.Entities;

namespace WebData.Configurations
{
    internal class DoctorEntityConfigurations : IEntityTypeConfiguration<DoctorEntity>
    {
        public void Configure(EntityTypeBuilder<DoctorEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.SurName).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.SecName).HasMaxLength(255);
            builder.HasOne(x => x.Post).WithMany().HasForeignKey(x => x.IdPost);
        }
    }
}
