using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Official.Domain.Model.Security.IUserRepository
{
    public interface IUserRepository : IDatabaseTransaction, IDisposable
    {
        Task<bool> Create(AppUserTransfer appUserTransfer);
        Task<long> Update(AppUserTransfer appUserTransfer);
        Task<int> Remove(long id);
        bool IsExistsUserName(AppUserTransfer appUserTransfer);
        bool IsExistsPerson(AppUserTransfer appUserTransfer);
        AppUserTransfer GetUserById(long userId);
        Task<long> GetUserIdByUserName(string userName);
        Task<int> CreateUserRole(long userId, List<long> roleIds);
        Task<int> RemoveUserRole(long userId);
        Task<int> UpdateUserRoleAsync(long userId, List<long> roleIds);
    }
}
