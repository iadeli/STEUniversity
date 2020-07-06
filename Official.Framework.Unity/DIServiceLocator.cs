using Microsoft.Extensions.DependencyInjection;
using Official.Framework.Core;

namespace Official.Framework.DI
{
    public class DIServiceLocator : IServiceLocator
    {
        private readonly IServiceCollection _services;
        private readonly ServiceProvider _serviceProvider;

        public DIServiceLocator(IServiceCollection services)
        {
            _services = services;
            _serviceProvider = _services.BuildServiceProvider();
        }

        public T GetInstance<T>()
        {
            return _serviceProvider.GetService<T>();
        }

        public void Release()
        {
            _serviceProvider.Dispose();
        }
    }
}
