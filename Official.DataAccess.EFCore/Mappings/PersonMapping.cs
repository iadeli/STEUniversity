﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Official.Domain.Model.Person;
using System;
using System.Collections.Generic;
using System.Text;

namespace Official.Persistence.EFCore.Mappings
{
    public class PersonMapping : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(a => a.Id);

            builder.HasOne<BirthCertificate>(a => a.BirthCertificate).WithOne(a => a.Person).HasForeignKey<BirthCertificate>(a => a.PersonId).IsRequired();
            builder.HasOne<PersonDetail>(a => a.PersonDetail).WithOne(a => a.Person).HasForeignKey<PersonDetail>(a => a.PersonId).IsRequired();
            builder.HasOne<Contact>(a => a.Contact).WithOne(a => a.Person).HasForeignKey<Contact>(a => a.PersonId).IsRequired();
            builder.HasMany<EducationalInfo>(a => a.EducationalInfos).WithOne(a => a.Person).HasForeignKey(a => a.PersonId);
            builder.HasMany<HistoryEducational>(a => a.HistoryEducationals).WithOne(a => a.Person).HasForeignKey(a => a.PersonId);
        }
    }
}
