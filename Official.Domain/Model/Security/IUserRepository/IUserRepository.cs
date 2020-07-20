using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Official.Domain.Model.Security.IUserRepository
{
    public interface IUserRepository : IDisposable
    {
        Task<AppUserTransfer> CreateUser(AppUserTransfer appUserTransfer);
        Task<AppUserTransfer> UpdateUser(AppUserTransfer appUserTransfer);
        Task<int> RemoveUserTransfer(long id);
    }
}
