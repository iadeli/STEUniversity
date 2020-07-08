using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Official.Domain.Model.Person;
using System;
using System.Collections.Generic;
using System.Text;

namespace Official.Persistence.EFCore.Mappings
{
    public class HistoryEducationalMapping : IEntityTypeConfiguration<HistoryEducational>
    {
        public void Configure(EntityTypeBuilder<HistoryEducational> builder)
        {
            builder.HasKey(a => a.Id);

            builder.HasMany<DegreeAttach>(a => a.DegreeAttaches).WithOne(a => a.HistoryEducational).IsRequired();
            builder.HasOne<Person>(a => a.Person).WithMany(a => a.HistoryEducationals).HasForeignKey(a => a.PersonId).IsRequired();
        }
    }
}
