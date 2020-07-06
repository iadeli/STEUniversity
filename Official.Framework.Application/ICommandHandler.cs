using System.Threading.Tasks;

namespace Official.Framework.Application
{
    public interface ICommandHandler<T>
    {
        Task<T> Handle(T command);
    }
}