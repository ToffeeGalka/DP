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
    internal class DispRegEntityConfigurations : IEntityTypeConfiguration<DispRegEntity>
    {
        public void Configure(EntityTypeBuilder<DispRegEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Patient).WithMany().HasForeignKey(x => x.IdPatient);
            builder.Property(x => x.DateTaken).IsRequired();
            builder.HasOne(x => x.ICD).WithMany().HasForeignKey(x => x.IdICD);
            builder.HasOne(x => x.Doctor).WithMany().HasForeignKey(x => x.IdDoctor);
            builder.Property(x => x.DateNotTaken);
            builder.HasOne(x => x.Reason).WithMany().HasForeignKey(x => x.IdReason);
        }
    }
}
