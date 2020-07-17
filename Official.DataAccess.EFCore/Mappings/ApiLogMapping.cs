using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Official.Domain.Model.Log;
using System;
using System.Collections.Generic;
using System.Text;

namespace Official.Persistence.EFCore.Mappings
{
    public class ApiLogMapping : IEntityTypeConfiguration<ApiLog>
    {
        public void Configure(EntityTypeBuilder<ApiLog> builder)
        {
            builder.HasKey(a => a.Id);
        }
    }
}
