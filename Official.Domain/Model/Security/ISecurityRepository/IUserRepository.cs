using System;
using System.Threading.Tasks;

namespace Official.Domain.Model.Security.ISecurityRepository
{
    public interface IUserRepository : IDisposable
    {
        Task<bool> Login(string userName, string password);
        bool Register(string userName, string password);
        Task<bool> Create(string userName, string password, long personId);
        Task<bool> IsExistsUserName(string userName);
    }
}
