using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Official.Config.DI;
using Official.Framework.DI;
using Official.Interface.Facade.Contracts.IFacadeQuery.Enum;
using Official.Interface.Facade.Contracts.IFacadeQuery.Menu;
using Official.Interface.Facade.Contracts.IFacadeQuery.Person;
using Official.Interface.Facade.Query.FacadeQuery.Enum;
using Official.Interface.Facade.Query.FacadeQuery.Menu;
using Official.Interface.Facade.Query.FacadeQuery.Person;
using ServiceHost.Configs;

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
            services.AddMvc(options => options.Filters.Add(new AuthorizeFilter()));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddMvc().AddApplicationPart(Assembly.Load(new AssemblyName("Official.Interface.RestApi")));
            services.AddMvc(opts =>
            {
                opts.Filters.Add(new AllowAnonymousFilter());
            });
            services.AddCors();

            //services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
            //    .AddIdentityServerAuthentication(options =>
            //    {
            //        options.Authority = "http://localhost:5000/";
            //        options.ApiName = "Official-api";
            //        options.RequireHttpsMetadata = false;
            //    });

            services.AddAuthentication(options =>
            {

                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.Authority = "http://localhost:5000/";
                o.Audience = "Official-api";
                o.RequireHttpsMetadata = false;
            });

            //services.AddScoped<UserStore<AppUser, AppRole, AppDbContext, long, AppUserClaim, AppUserRole, AppUserLogin, AppUserToken, AppRoleClaim>, ApplicationUserStore>();
            //services.AddScoped<UserManager<AppUser>, ApplicationUserManager>();
            //services.AddScoped<RoleManager<AppRole>, ApplicationRoleManager>();
            //services.AddScoped<SignInManager<AppUser>, ApplicationSignInManager>();
            //services.AddScoped<RoleStore<AppRole, AppDbContext, long, AppUserRole, AppRoleClaim>, ApplicationRoleStore>();
            //services.AddIdentity<AppUser, AppRole>(identityOptions =>
            //{
            //})
            //.AddUserStore<ApplicationUserStore>()
            //.AddUserManager<ApplicationUserManager>()
            //.AddRoleStore<ApplicationRoleStore>()
            //.AddRoleManager<ApplicationRoleManager>()
            //.AddSignInManager<ApplicationSignInManager>()
            //.AddDefaultTokenProviders();
            //services.AddAuthentication()
            //    .AddCookie(cfg =>
            //    {
            //        cfg.SlidingExpiration = true;
            //        cfg.LoginPath = "/AppIdentity/Account/Login";
            //    })
            //    .AddJwtBearer(cfg =>
            //    {
            //        cfg.TokenValidationParameters = new TokenValidationParameters()
            //        {
            //            ValidIssuer = MvsJwtTokens.Issuer,
            //            ValidAudience = MvsJwtTokens.Audience,
            //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(MvsJwtTokens.Key))
            //        };
            //    });
            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("ViewPolicy", policy => policy.AddRequirements(new ManageMPolicyRequirement()));
            //    options.AddPolicy("CreatePolicy", policy => policy.AddRequirements(new ManageMPolicyRequirement()));
            //    options.AddPolicy("EditPolicy", policy => policy.AddRequirements(new ManageMPolicyRequirement()));
            //    options.AddPolicy("DeletePolicy", policy => policy.AddRequirements(new ManageMPolicyRequirement())); ;
            //});
            //services.AddTransient<IAuthorizationHandler, ManagePolicyHandler>();

            WireUp(services);
        }

        private void WireUp(IServiceCollection services)
        {
            FrameworkBootstrapper.WireUp(services);
            OfficialBootstrapper.WireUp(services, _officialConfig.ConnectionStrings.MainDbConnection);

            services.AddScoped<IMenuFacadeQuery, MenuFacadeQuery>();
            services.AddScoped<IEnumFacadeQuery, EnumFacadeQuery>();
            services.AddScoped<IPlaceFacadeQuery, PlaceFacadeQuery>();
            services.AddScoped<IPersonFacadeQuery, PersonFacadeQuery>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.UseMvc();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseCors(builder => builder.Apply(_officialConfig.CorsOption));
            app.UseMvcWithDefaultRoute();
            app.UseStatusCodePages();
        }
    }
}
