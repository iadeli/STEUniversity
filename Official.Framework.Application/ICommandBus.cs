using System.Threading.Tasks;

namespace Official.Framework.Application
{
    public interface ICommandBus
    {
        Task<T> Dispatch<T>(T command);
    }
}
