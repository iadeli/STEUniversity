using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Official.Domain.Model.Security.IRoleRepository
{
    public interface IRoleRepository : IDatabaseTransaction, IDisposable
    {
        Task<bool> IsExistsRoleAsync(long id, string name);
        Task<long> Create(string name);
        Task<int> CreateUserRole(long roleId, List<long> userIds);
        Task<long> UpdateAsync(long id, string name);
        Task<int> RemoveUserRole(long roleId);
        Task<int> Remove(long id);
    }
}
