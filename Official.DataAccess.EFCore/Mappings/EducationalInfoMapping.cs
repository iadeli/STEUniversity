using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Official.Domain.Model.CommonEntity;
using Official.Domain.Model.Person;

namespace Official.Persistence.EFCore.Mappings
{
    public class EducationalInfoMapping : IEntityTypeConfiguration<EducationalInfo>
    {
        public void Configure(EntityTypeBuilder<EducationalInfo> builder)
        {
            builder.HasKey(a => a.Id);

            builder.HasOne<Person>(a => a.Person).WithMany(a => a.EducationalInfos).HasForeignKey(a => a.PersonId).IsRequired();
            builder.HasOne<Term>(a => a.Term).WithMany(a => a.EducationalInfos).HasForeignKey(a => a.TermId).IsRequired();
        }
    }
}
