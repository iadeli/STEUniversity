using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Official.Application.Attribute;
using Official.Application.Command.Person;
using Official.Application.Contracts.Command.Person;
using Official.Domain.Model.Person.IPersonRepository;
using Official.Framework.Application;
using Official.Persistence.EFCore;
using Official.Persistence.EFCore.Context;
using Official.Persistence.EFCore.Repositories;

namespace Official.Config.DI
{
    public static class OfficialBootstrapper
    {
        public static void WireUp(IServiceCollection services, string connectionString)
        {
            services.AddScoped<STEDbContext>(sp => new OfficialContextFactory().CreateDbContext(new string[] { }));
            services.AddScoped<IDbConnection>(sp => new SqlConnection(connectionString));
            services.AddScoped<LoggingActionFilter>();

            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<ICommandHandler<CreatePersonCommand>, PersonCommandHandlers>();
        }
    }
}
