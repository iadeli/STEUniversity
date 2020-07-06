using Microsoft.Extensions.DependencyInjection;
using Official.Framework.Application;
using Official.Framework.Core;

namespace Official.Framework.DI
{
    public static class FrameworkBootstrapper
    {
        public static void WireUp(IServiceCollection services)
        {
            services.AddScoped<IServiceLocator>(sp => new DIServiceLocator(services));
            services.AddScoped<ICommandBus, CommandBus>();
        }
    }
}
