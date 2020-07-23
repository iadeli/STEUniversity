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
        List<long> GetControllerIdByType(string entityName, string policy);
        Task RemoveRoleClaims(List<ClaimTransfer> roleClaimTransfers);
        Task CreateRoleClaims(List<ClaimTransfer> roleClaimTransfers);
        Task RemoveUserClaims(List<ClaimTransfer> removeUserClaimList);
        Task CreateUserClaims(List<ClaimTransfer> addUserClaimList);
    }
}
