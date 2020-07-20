using Official.QueryModel.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Official.Interface.Facade.Contracts.IFacadeQuery.Security
{
    public interface ISecurityFacadeQuery
    {
        Task<List<UserAccessQuery>> GetUserClaim(long userId, string type);
        Task<List<RoleAccessQuery>> GetRoleClaim(long roleId, string type);
    }
}
