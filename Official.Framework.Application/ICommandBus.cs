using System.Threading.Tasks;

namespace Official.Framework.Application
{
    public interface ICommandBus
    {
        Task<Z> Dispatch<T,Z>(T command);
    }
}
