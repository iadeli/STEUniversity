using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Official.Domain.Model.CommonEntity;
using Official.Domain.Model.Person;
using System;
using System.Collections.Generic;
using System.Text;
using Official.Domain.Model.CommonEntity.Term;

namespace Official.Persistence.EFCore.Mappings
{
    public class TermMapping : IEntityTypeConfiguration<Term>
    {
        public void Configure(EntityTypeBuilder<Term> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.FromYear).HasMaxLength(10);
            builder.Property(a => a.ToYear).HasMaxLength(10);

            builder.HasMany<EducationalInfo>(a => a.EducationalInfos).WithOne(a => a.Term).HasForeignKey(a => a.TermId);
        }
    }
}
