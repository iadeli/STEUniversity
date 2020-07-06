using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Official.Domain.Model.Person.IUserRepository
{
    public interface IUserRepository : IDisposable
    {
        Task<bool> Login(string userName, string password);
        Task<bool> Register(string userName, string password);
        Task<bool> Create(string userName, string password, long personId);
        Task<bool> IsExistsUserName(string userName);
    }
}
