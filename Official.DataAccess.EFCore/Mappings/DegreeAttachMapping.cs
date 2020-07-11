using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Official.Domain.Model.Person;
using System;
using System.Collections.Generic;
using System.Text;

namespace Official.Persistence.EFCore.Mappings
{
    public class DegreeAttachMapping : IEntityTypeConfiguration<DegreeAttach>
    {
        public void Configure(EntityTypeBuilder<DegreeAttach> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.AttachFile).IsRequired();
            builder.Property(a => a.Extention).HasMaxLength(500).IsRequired();

            builder.HasOne<HistoryEducational>(a => a.HistoryEducational).WithMany(a => a.DegreeAttaches).HasForeignKey(a => a.HistoryEducationalId).IsRequired();
        }
    }
}
