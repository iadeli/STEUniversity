using Dapper;
using Official.Interface.Facade.Contracts.IFacadeQuery.Security;
using Official.QueryModel.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Official.Persistence.EFCore.Resourse;
using Official.Interface.Facade.Contracts.Utility;

namespace Official.Interface.Facade.Query.FacadeQuery.Security
{
    public class SecurityFacadeQuery : ISecurityFacadeQuery
    {
        private readonly IDbConnection _connection;
        public SecurityFacadeQuery(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<List<UserAccessQuery>> GetUserClaim(long userId, string type)
        {
            try
            {
                IEnumerable<UserAccessQuery> userClaims = new List<UserAccessQuery>();
                var sql = string.Empty;
                if (type == "ProvinceId")
                {
                    sql = @" 
                        SELECT @UserId AS UserId, @ProvinceId AS ClaimType, p.Id AS ClaimValue, p.[Name] AS ClaimTitle, 
                        CASE WHEN EXISTS (SELECT * FROM AspNetUserClaims WHERE UserId = @UserId AND ClaimType = @ProvinceId AND ClaimValue = p.Id) THEN 1 ELSE 0 END AS Checked 
                        FROM Places p 
                        WHERE Type = 2 AND PlaceId = (SELECT TOP 1 ID FROM Places) ";
                    userClaims = await _connection.QueryAsync<UserAccessQuery>(sql, new { UserId = userId, ProvinceId = type });
                }
                else if (type == "PositionId")
                {
                    sql = @"
                        SELECT @UserId AS UserId, @PositionId AS ClaimType, e.EnumValue AS ClaimValue, e.EnumTitle AS ClaimTitle, 
                        CASE WHEN EXISTS (SELECT * FROM AspNetUserClaims WHERE UserId = @UserId AND ClaimType = @PositionId AND ClaimValue = e.EnumValue) THEN 1 ELSE 0 END AS Checked 
                        FROM Enumurations e 
                        WHERE EnumName = @PositionId
                        ";
                    userClaims = await _connection.QueryAsync<UserAccessQuery>(sql, new { UserId = userId, PositionId = type });
                }
                return userClaims.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<RoleAccessQuery>> GetRoleClaim(long roleId, string type)
        {
            try
            {
                IEnumerable<RoleAccessQuery> roleClaims = new List<RoleAccessQuery>();
                var sql = string.Empty;
                if (type == "ControllerInfoId")
                    sql = @"
                        SELECT @RoleId AS RoleId, @ControllerInfoId AS ClaimType, Min(Id) AS ClaimValue, 'EnumTitle' AS ClaimTitle, [Policy], Controller AS Entity, 
                        CASE WHEN EXISTS (SELECT * FROM AspNetRoleClaims WHERE RoleId = @RoleId AND ClaimType = @ControllerInfoId AND ClaimValue = Min(c.Id)) THEN 1 ELSE 0 END AS Checked 
                        FROM ControllerInfos c 
                        GROUP BY Controller, [Policy] ORDER BY Controller, [Policy]
                        ";
                roleClaims = await _connection.QueryAsync<RoleAccessQuery>(sql, new { RoleId = roleId, ControllerInfoId = type });
                roleClaims = roleClaims.Select(a => new RoleAccessQuery()
                {
                    ClaimTitle = ResourceEntity.ResourceManager.GetString(a.Entity),
                    ClaimType = a.ClaimType,
                    ClaimValue = a.ClaimValue,
                    Entity = a.Entity,
                    RoleId = a.RoleId,
                    AddPolicy = GetPolicy("AddPolicy", a, roleClaims),
                    DeletePolicy = GetPolicy("DeletePolicy", a, roleClaims),
                    EditPolicy = GetPolicy("EditPolicy", a, roleClaims),
                    ViewPolicy = GetPolicy("ViewPolicy", a, roleClaims),
                }).ToList().GroupBy(x => x.Entity).Select(x => x.First());
                return roleClaims.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private bool? GetPolicy(string actionType, RoleAccessQuery roleAccess, IEnumerable<RoleAccessQuery> roleClaims)
        {
            bool isExistsPolicy = roleClaims.Where(r => r.Entity == roleAccess.Entity && r.Policy == actionType).Any();
            if (!isExistsPolicy)
                return null;
            return roleAccess.Checked;
        }
    }
}