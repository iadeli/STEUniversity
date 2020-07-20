using Official.QueryModel.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Official.Interface.Facade.Contracts.IFacadeQuery.Security.Role
{
    public interface IRoleFacadeQuery
    {
        Task<List<RoleQuery>> Get();
        Task<List<RoleQuery>> GetRoleByIdAsync(long roleId);
        Task<List<RoleQuery>> GetRoleByPersonIdAsync(long PersonId);
    }
}
