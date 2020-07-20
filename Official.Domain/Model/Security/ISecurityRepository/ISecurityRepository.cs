using Official.Domain.Model.Authorization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Official.Domain.Model.Security.ISecurityRepository
{
    public interface ISecurityRepository : IDatabaseTransaction, IDisposable
    {
        bool Register(string userName, string password);
        Task<bool> Login(string userName, string password);
        Task<bool> IsExistsRoleNameAsync(string roleName);
        Task<bool> CreateRoleAsync(string roleName);
        Task<long> GetRoleIdByRoleNameAsync(string roleName);
        Task<int> CreateRoleUserAsync(long roleId, List<long> userIds);
        Task<int> CreateRoleClaims(RoleClaimTransfer roleClaimTransfer);
    }
}
