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
    internal class ICDEntityConfigurations : IEntityTypeConfiguration<ICDEntity>
    {
        public void Configure(EntityTypeBuilder<ICDEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ParentId).HasMaxLength(255);
            builder.Property(x => x.ICDCode).IsRequired().HasMaxLength(255);
            builder.Property(x => x.NameCode).IsRequired().HasMaxLength(255);
        }
    }
}
