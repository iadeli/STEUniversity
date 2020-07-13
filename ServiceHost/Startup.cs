﻿using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Official.Config.DI;
using Official.Framework.DI;
using Official.Interface.Facade.Contracts.IFacadeQuery.AuditEntry;
using Official.Interface.Facade.Contracts.IFacadeQuery.Enum;
using Official.Interface.Facade.Contracts.IFacadeQuery.Menu;
using Official.Interface.Facade.Contracts.IFacadeQuery.Person;
using Official.Interface.Facade.Contracts.IFacadeQuery.Term;
using Official.Interface.Facade.Query.FacadeQuery.AuditEntry;
using Official.Interface.Facade.Query.FacadeQuery.Enum;
using Official.Interface.Facade.Query.FacadeQuery.HireStage;
using Official.Interface.Facade.Query.FacadeQuery.Menu;
using Official.Interface.Facade.Query.FacadeQuery.Person;
using Official.Interface.Facade.Query.FacadeQuery.Term;
using Official.Persistence.EFCore.Context;
using Official.Persistence.EFCore.Identity;
using Official.Persistence.EFCore.Jwt;
using Official.Persistence.EFCore.Utility;
using ServiceHost.Configs;
using ServiceHost.Utility;
using Swashbuckle.AspNetCore.Swagger;

namespace ServiceHost
{
    public class Startup
    {
        private readonly OfficialConfig _officialConfig;
        public Startup(IConfiguration configuration)
        {
            //Configuration = configuration;

            _officialConfig = configuration.Get<OfficialConfig>();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddMvc().AddApplicationPart(Assembly.Load(new AssemblyName("Official.Interface.RestApi")));
            services.AddMvc(options => options.Filters.Add(new AuthorizeFilter()));

            services.AddScoped<UserStore<AppUser, AppRole, STEDbContext, long, AppUserClaim, AppUserRole, AppUserLogin, AppUserToken, AppRoleClaim>, ApplicationUserStore>();
            services.AddScoped<UserManager<AppUser>, ApplicationUserManager>();
            services.AddScoped<RoleManager<AppRole>, ApplicationRoleManager>();
            services.AddScoped<SignInManager<AppUser>, ApplicationSignInManager>();
            services.AddScoped<RoleStore<AppRole, STEDbContext, long, AppUserRole, AppRoleClaim>, ApplicationRoleStore>();

            services.AddIdentity<AppUser, AppRole>(identityOptions =>
                {
                    identityOptions.Password.RequiredLength = 1;
                    identityOptions.Password.RequireNonAlphanumeric = false;
                    identityOptions.Password.RequireLowercase = false;
                    identityOptions.Password.RequireUppercase = false;
                }).AddUserStore<ApplicationUserStore>()
                .AddUserManager<ApplicationUserManager>()
                .AddRoleStore<ApplicationRoleStore>()
                .AddRoleManager<ApplicationRoleManager>()
                .AddSignInManager<ApplicationSignInManager>()
                // You **cannot** use .AddEntityFrameworkStores() when you customize everything
                //.AddEntityFrameworkStores<ApplicationDbContext, int>()
                .AddDefaultTokenProviders();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
                {
                    cfg.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidIssuer = MvsJwtTokens.Issuer,
                        ValidAudience = MvsJwtTokens.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(MvsJwtTokens.Key))
                    };
                });

            WireUp(services);

            services.AddCors();
            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Test API",
                    Description = "ASP.NET Core Web API"
                });

                c.AddSecurityDefinition("Bearer", new ApiKeyScheme()
                {
                    Description = "Authorization header using the Bearer scheme",
                    Name = "Authorization",
                    In = "header"
                });

                c.DocumentFilter<SwaggerSecurityRequirementsDocumentFilter>();

                //Locate the XML file being generated by ASP.NET...
                var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies();
                var xmlPath = Assembly.GetExecutingAssembly().GetReferencedAssemblies()
                    .Select(name => loadedAssemblies.SingleOrDefault(a => a.GetName().Name == "Official.Interface.RestApi")?.Location)
                    .Where(l => l != null).FirstOrDefault().Replace(".dll", ".xml");

                //... and tell Swagger to use those XML comments.
                c.IncludeXmlComments(xmlPath);
            });

            //services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
            //    .AddIdentityServerAuthentication(options =>
            //    {
            //        options.Authority = "http://localhost:5000/";
            //        options.ApiName = "Official-api";
            //        options.RequireHttpsMetadata = false;
            //    });
        }

        private void WireUp(IServiceCollection services)
        {
            FrameworkBootstrapper.WireUp(services);
            OfficialBootstrapper.WireUp(services, _officialConfig.ConnectionStrings.MainDbConnection);

            services.AddScoped<IEnumFacadeQuery, EnumFacadeQuery>();
            services.AddScoped<IPlaceFacadeQuery, PlaceFacadeQuery>();
            services.AddScoped<IMenuFacadeQuery, MenuFacadeQuery>();
            services.AddScoped<ITermFacadeQuery, TermFacadeQuery>();
            services.AddScoped<IPersonFacadeQuery, PersonFacadeQuery>();
            services.AddScoped<IEducationalInfoFacadeQuery, EducationalInfoFacadeQuery>();
            services.AddScoped<IHistoryEducationalFacadeQuery, HistoryEducationalFacadeQuery>();
            services.AddScoped<IHireStageFacadeQuery, HireStageFacadeQuery>();
            services.AddScoped<IAuditEntryFacadeQuery, AuditEntryFacadeQuery>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseCors(builder => builder.Apply(_officialConfig.CorsOption));
            app.UseMvcWithDefaultRoute();
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Test API V1");
            });
            app.UseStatusCodePages();
        }
    }
}
