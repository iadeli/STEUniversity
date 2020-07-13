using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Official.Domain.Model.Person;
using System;
using System.Collections.Generic;
using System.Text;
using Official.Domain.Model.CommonEntity.HireStage;

namespace Official.Persistence.EFCore.Mappings
{
    public class HireStageMapping : IEntityTypeConfiguration<HireStage>
    {
        public void Configure(EntityTypeBuilder<HireStage> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name).IsRequired();
        }
    }
}
