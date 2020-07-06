using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Official.Persistence.EFCore.Context
{
    public class OfficialContextFactory : IDesignTimeDbContextFactory<STEDbContext>
    {
        public STEDbContext CreateDbContext(string[] connectionStrings)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            // Here we create the DbContextOptionsBuilder manually.        
            var builder = new DbContextOptionsBuilder<STEDbContext>();

            // Build connection string. This requires that you have a connectionstring in the appsettings.json
            var connectionString = configuration.GetConnectionString("MainDbConnection");
            builder.UseSqlServer(connectionString);
            // Create our DbContext.
            return new STEDbContext(builder.Options);
        }
    }
}
