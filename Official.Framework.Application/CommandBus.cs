using System;
using System.Threading.Tasks;
using Official.Framework.Core;

namespace Official.Framework.Application
{
    public class CommandBus : ICommandBus
    {
        private readonly IServiceLocator _serviceLocator;

        public CommandBus(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }

        public async Task<Z> Dispatch<T,Z>(T command)
        {
            var handler = _serviceLocator.GetInstance<ICommandHandler<T,Z>>();
            return await handler.Handle(command);
        }
    }
}