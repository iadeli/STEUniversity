using System.Threading.Tasks;

namespace Official.Framework.Application
{
    public interface ICommandHandler<T,Z>
    {
        Task<Z> HandleAsync(T command);
    }
}