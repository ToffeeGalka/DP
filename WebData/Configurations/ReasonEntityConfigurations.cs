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
    internal class ReasonEntityConfigurations : IEntityTypeConfiguration<ReasonEntity>
    {
        public void Configure(EntityTypeBuilder<ReasonEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ReasonName).IsRequired().HasMaxLength(255);
        }
    }
}
