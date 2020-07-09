using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Official.Domain.Model.Person;
using System;
using System.Collections.Generic;
using System.Text;

namespace Official.Persistence.EFCore.Mappings
{
    public class ContactMapping : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasKey(a => a.PersonId);

            builder.HasOne<Person>(a => a.Person).WithOne(a => a.Contact).HasForeignKey<Contact>(a => a.PersonId);
        }
    }
}
