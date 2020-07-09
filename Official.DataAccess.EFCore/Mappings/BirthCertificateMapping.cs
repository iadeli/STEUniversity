using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Official.Domain.Model.Person;
using System;
using System.Collections.Generic;
using System.Text;

namespace Official.Persistence.EFCore.Mappings
{
    public class BirthCertificateMapping : IEntityTypeConfiguration<BirthCertificate>
    {
        public void Configure(EntityTypeBuilder<BirthCertificate> builder)
        {
            builder.HasKey(a => a.PersonId);

            builder.HasOne<Person>(a => a.Person).WithOne(a => a.BirthCertificate).HasForeignKey<BirthCertificate>(a => a.PersonId);
        }
    }
}
