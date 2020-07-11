using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Official.Domain.Model.CommonEntity.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Official.Persistence.EFCore.Mappings
{
    public class EnumurationMapping : IEntityTypeConfiguration<Enumuration>
    {
        public void Configure(EntityTypeBuilder<Enumuration> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.EnumName).IsRequired();
            builder.Property(a => a.EnumTitle).IsRequired();
            builder.Property(a => a.EnumValue).IsRequired();
        }
    }
}
