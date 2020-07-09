using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Official.Domain.Model.Person;
using System;
using System.Collections.Generic;
using System.Text;

namespace Official.Persistence.EFCore.Mappings
{
    public class PersonDetailMapping : IEntityTypeConfiguration<PersonDetail>
    {
        public void Configure(EntityTypeBuilder<PersonDetail> builder)
        {
            builder.HasKey(a => a.PersonId);

            builder.HasOne<Person>(a => a.Person).WithOne(a => a.PersonDetail).HasForeignKey<PersonDetail>(a => a.PersonId);
        }
    }
}
