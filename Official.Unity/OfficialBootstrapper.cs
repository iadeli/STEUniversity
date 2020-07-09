using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Official.Application.Attribute;
using Official.Application.Command.Person;
using Official.Application.Command.User;
using Official.Application.Contracts.Command.Person;
using Official.Application.Contracts.Command.User;
using Official.Domain.Model.Person.EducationalInfoRepository;
using Official.Domain.Model.Person.IPersonRepository;
using Official.Domain.Model.Person.IUserRepository;
using Official.Domain.Model.Security;
using Official.Framework.Application;
using Official.Persistence.EFCore;
using Official.Persistence.EFCore.Context;
using Official.Persistence.EFCore.Identity;
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

            //services.AddScoped<IJwtRepository, JwtRepository>();
            services.Add(new ServiceDescriptor(typeof(IJwtRepository), new JwtRepository()));

            //services.AddScoped<IUserRepository, UserRepository>();
            var serviceProvider = services.BuildServiceProvider();
            var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
            var signInManager = serviceProvider.GetRequiredService<SignInManager<AppUser>>();
            var context = serviceProvider.GetRequiredService<STEDbContext>();
            services.Add(new ServiceDescriptor(typeof(IUserRepository), new UserRepository(userManager, signInManager, context)));

            services.AddScoped<ICommandHandler<CreateUserCommand>, UserCommandHandlers>();
            services.AddScoped<ICommandHandler<LoginCommand>, UserCommandHandlers>();

            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<ICommandHandler<CreatePersonCommand>, PersonCommandHandlers>();
            services.AddScoped<ICommandHandler<UpdatePersonCommand>, PersonCommandHandlers>();
            services.AddScoped<ICommandHandler<DeletePersonCommand>, PersonCommandHandlers>();

            services.AddScoped<IEducationalInfoRepository, EducationalInfoRepository>();
            services.AddScoped<ICommandHandler<CreateEducationalInfoCommand>, EducationalInfoCommandHandlers>();
            services.AddScoped<ICommandHandler<UpdateEducationalInfoCommand>, EducationalInfoCommandHandlers>();
            services.AddScoped<ICommandHandler<DeleteEducationalInfoCommand>, EducationalInfoCommandHandlers>();
        }
    }
}
