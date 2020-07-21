using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Official.Application.Attribute;
using Official.Application.Command.ApiLog;
using Official.Application.Command.Person;
using Official.Application.Command.Security;
using Official.Application.Command.Term;
using Official.Application.Contracts.Command.Log.ApiLogItem;
using Official.Application.Contracts.Command.Person;
using Official.Application.Contracts.Command.Person.EducationalInfoCommand;
using Official.Application.Contracts.Command.Person.HireStageCommand;
using Official.Application.Contracts.Command.Person.HistoryEducationalCommand;
using Official.Application.Contracts.Command.Person.PersonCommand;
using Official.Application.Contracts.Command.Security;
using Official.Application.Contracts.Command.Security.Role;
using Official.Application.Contracts.Command.Security.User;
using Official.Application.Contracts.Command.Term;
using Official.Domain.Model.CommonEntity.Term.ITermRepository;
using Official.Domain.Model.Log.IApiLogRepository;
using Official.Domain.Model.Person.IEducationalInfoRepository;
using Official.Domain.Model.Person.IHireStageRepository;
using Official.Domain.Model.Person.IHistoryEducationalRepository;
using Official.Domain.Model.Person.IPersonRepository;
using Official.Domain.Model.Security;
using Official.Domain.Model.Security.IRoleRepository;
using Official.Domain.Model.Security.ISecurityRepository;
using Official.Domain.Model.Security.IUserRepository;
using Official.Framework.Application;
using Official.Persistence.EFCore;
using Official.Persistence.EFCore.Context;
using Official.Persistence.EFCore.Identity;
using Official.Persistence.EFCore.Repositories;
using Official.Persistence.EFCore.Utility;

namespace Official.Config.DI
{
    public static class OfficialBootstrapper
    {
        public static void WireUp(IServiceCollection services, string connectionString)
        {
            services.AddScoped<STEDbContext>(sp => new STEContextFactory().CreateDbContext(new string[] { }));
            services.AddScoped<IDbConnection>(sp => new SqlConnection(connectionString));
            //services.AddScoped<LoggingActionFilter>();
            var serviceProvider = services.BuildServiceProvider();
            var context = serviceProvider.GetRequiredService<STEDbContext>();
            services.AddScoped<UserResolverService>();

            services.Add(new ServiceDescriptor(typeof(IJwtRepository), new JwtRepository(context)));
            var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<AppRole>>();
            var signInManager = serviceProvider.GetRequiredService<SignInManager<AppUser>>();            
            services.Add(new ServiceDescriptor(typeof(ISecurityRepository), new SecurityRepository(userManager, roleManager, signInManager, context)));
            services.AddScoped<ICommandHandler<LoginCommand, JwtTokenDto>, SecurityCommandHandlers>();
            services.AddScoped<ICommandHandler<string, JwtTokenDto>, SecurityCommandHandlers>();
            services.AddScoped<ICommandHandler<CreateRoleClaimCommand, bool>, SecurityCommandHandlers>();

            services.Add(new ServiceDescriptor(typeof(IUserRepository), new UserRepository(userManager, context)));
            services.AddScoped<ICommandHandler<CreateUserCommand, long>, UserCommandHandlers>();
            services.AddScoped<ICommandHandler<UpdateUserCommand, long>, UserCommandHandlers>();
            services.AddScoped<ICommandHandler<RemoveUserCommand, int>, UserCommandHandlers>();
            
            services.Add(new ServiceDescriptor(typeof(IRoleRepository), new RoleRepository(context, roleManager)));
            services.AddScoped<ICommandHandler<CreateRoleCommand, long>, RoleCommandHandlers>();
            services.AddScoped<ICommandHandler<UpdateRoleCommand, long>, RoleCommandHandlers>();
            services.AddScoped<ICommandHandler<RemoveRoleCommand, int>, RoleCommandHandlers>();

            services.AddScoped<IApiLogRepository, ApiLogRepository>();
            services.AddScoped<ICommandHandler<CreateApiLogCommand, long>, ApiLogCommandHandlers>();

            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<ICommandHandler<CreatePersonCommand, long>, PersonCommandHandlers>();
            services.AddScoped<ICommandHandler<UpdatePersonCommand, long>, PersonCommandHandlers>();
            services.AddScoped<ICommandHandler<DeletePersonCommand, int>, PersonCommandHandlers>();

            services.AddScoped<IEducationalInfoRepository, EducationalInfoRepository>();
            services.AddScoped<ICommandHandler<CreateEducationalInfoCommand, long>, EducationalInfoCommandHandlers>();
            services.AddScoped<ICommandHandler<UpdateEducationalInfoCommand, long>, EducationalInfoCommandHandlers>();
            services.AddScoped<ICommandHandler<DeleteEducationalInfoCommand, int>, EducationalInfoCommandHandlers>();

            services.AddScoped<ITermRepository, TermRepository>();
            services.AddScoped<ICommandHandler<CreateTermCommand, long>, TermCommandHandlers>();
            services.AddScoped<ICommandHandler<UpdateTermCommand, long>, TermCommandHandlers>();
            services.AddScoped<ICommandHandler<DeleteTermCommand, int>, TermCommandHandlers>();

            services.AddScoped<IHistoryEducationalRepository, HistoryEducationalRepository>();
            services.AddScoped<ICommandHandler<CreateHistoryEducationalCommand, long>, HistoryEducationalCommandHandlers>();
            services.AddScoped<ICommandHandler<UpdateHistoryEducationalCommand, long>, HistoryEducationalCommandHandlers>();
            services.AddScoped<ICommandHandler<DeleteHistoryEducationalCommand, int>, HistoryEducationalCommandHandlers>();

            services.AddScoped<IHireStageRepository, HireStageRepository>();
            services.AddScoped<ICommandHandler<CreateHireStageCommand, long>, HireStageCommandHandlers>();
            services.AddScoped<ICommandHandler<UpdateHireStageCommand, long>, HireStageCommandHandlers>();
            services.AddScoped<ICommandHandler<DeleteHireStageCommand, int>, HireStageCommandHandlers>();
        }
    }
}
