using Official.Interface.Facade.Contracts.IFacadeQuery.Security.Role;
using Official.QueryModel.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Linq;

namespace Official.Interface.Facade.Query.FacadeQuery.Security.Role
{
    public class RoleFacadeQuery : IRoleFacadeQuery
    {
        private readonly IDbConnection _connection;
        public RoleFacadeQuery(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<List<RoleQuery>> Get()
        {
            try
            {
                var sql = @" SELECT * FROM AspNetRoles ";
                var roles = await _connection.QueryAsync<RoleQuery>(sql);
                roles = roles.Select(a => new RoleQuery()
                {
                    Id = a.Id,
                    Name = a.Name,
                    UserIds = _connection.Query<long>($"SELECT UserId FROM AspNetUserRoles WHERE RoleId = {a.Id}").ToList()
                });
                return roles.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<RoleQuery>> GetRoleByIdAsync(long roleId)
        {
            try
            {
                var sql = " SELECT * FROM AspNetRoles WHERE Id = @RoleId ";
                var roles = await _connection.QueryAsync<RoleQuery>(sql, new { RoleId = roleId });
                roles = roles.Select(a => new RoleQuery() {

                    Id = a.Id,
                    Name = a.Name,
                    UserIds = _connection.Query<long>($"SELECT UserId FROM AspNetUserRoles WHERE RoleId = {a.Id}").ToList()
                });
                return roles.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<RoleQuery>> GetRoleByPersonIdAsync(long PersonId)
        {
            try
            {
                var sql = " SELECT anr.* FROM AspNetRoles anr INNER JOIN AspNetUserRoles anur ON anr.Id = anur.RoleId INNER JOIN AspNetUsers anu ON anur.UserId = anu.Id WHERE anu.PersonId = @PersonId ";
                var roles = await _connection.QueryAsync<RoleQuery>(sql, new { PersonId = PersonId });
                return roles.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}