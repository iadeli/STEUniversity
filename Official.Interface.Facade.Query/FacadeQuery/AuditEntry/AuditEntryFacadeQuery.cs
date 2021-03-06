﻿using Official.Interface.Facade.Contracts.IFacadeQuery.AuditEntry;
using Official.QueryModel.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Linq;
using Official.Application.Contracts.Command.Log.ApiLogItem;
using Official.Application.Contracts.Command.Log.AuditEntry;
using System.Security.Claims;
using Official.Persistence.EFCore.Utility;
using Microsoft.AspNetCore.Http;
using static Official.Persistence.EFCore.Utility.Constant;

namespace Official.Interface.Facade.Query.FacadeQuery.AuditEntry
{
    public class AuditEntryFacadeQuery : IAuditEntryFacadeQuery
    {
        private readonly IDbConnection _connection;
        public AuditEntryFacadeQuery(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<List<AuditEntryDto>> GetAuditLogAsync()
        {
            try
            {
                var sql =
                    @" 
                        SELECT AuditEntryID, CreatedBy, pu.NationalCode, (pu.FirstName + ' ' + pu.LastName) AS FullName, (SELECT FORMAT(CreatedDate, 'yyyy/MM/dd-HH:mm:ss', 'fa')) AS CreatedDate, EntitySetName, 
                            (CASE WHEN [State] = 0 THEN N'ایجاد' WHEN [State] = 2 THEN N'ویرایش' ELSE N'حذف' END) AS StateName, EntityTypeName, [State] 
                        FROM AuditEntries ae 
                        INNER JOIN (
                            SELECT p.*, u.UserName FROM Persons p INNER JOIN AspNetUsers u ON p.Id = u.PersonId
                        ) pu ON ae.CreatedBy = pu.UserName
                        ORDER BY CreatedDate DESC
                    ";
                var data = await _connection.QueryAsync<AuditEntryDto>(sql);
                return data.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<AuditEntryDto>> GetAuditLogByFilterAsync(AuditEntryQuery auditEntryQuery)
        {
            try
            {
                var sql =
                    @" 
                        SELECT AuditEntryID, CreatedBy, pu.NationalCode, (pu.FirstName + ' ' + pu.LastName) AS FullName, (SELECT FORMAT(CreatedDate, 'yyyy/MM/dd-HH:mm:ss', 'fa')) AS CreatedDate, EntitySetName, 
                            (CASE WHEN [State] = 0 THEN N'ایجاد' WHEN [State] = 2 THEN N'ویرایش' ELSE N'حذف' END) AS StateName, EntityTypeName, [State] 
                        FROM AuditEntries ae 
                        INNER JOIN (
                            SELECT p.*, u.UserName FROM Persons p INNER JOIN AspNetUsers u ON p.Id = u.PersonId
                        ) pu ON ae.CreatedBy = pu.UserName
                        WHERE CreatedBy = ISNULL(@CreatedBy, CreatedBy) AND 
                            (SELECT FORMAT(CreatedDate, 'yyyy/MM/dd-HH:mm:ss', 'fa')) BETWEEN ISNULL(@FromDate, (SELECT FORMAT(CreatedDate, 'yyyy/MM/dd-HH:mm:ss', 'fa'))) AND ISNULL(@ToDate, (SELECT FORMAT(CreatedDate, 'yyyy/MM/dd-HH:mm:ss', 'fa'))) AND 
                            EntityTypeName = ISNULL(@EntityTypeName, EntityTypeName) AND [State] = ISNULL(@State, State) AND NationalCode = ISNULL(@NationalCode, NationalCode)
                        ORDER BY CreatedDate DESC
                     ";
                var data = await _connection.QueryAsync<AuditEntryDto>(sql, new { CreatedBy = auditEntryQuery.CreatedBy, FromDate = auditEntryQuery.FromDate, ToDate = auditEntryQuery.ToDate, EntityTypeName = auditEntryQuery.EntityTypeName, State = auditEntryQuery.State, NationalCode = auditEntryQuery.NationalCode });
                return data.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<AuditEntryPropertyQuery>> GetPropertyAuditLogAsync(int auditLogId)
        {
            try
            {
                var sql = " SELECT * FROM AuditEntryProperties WHERE AuditEntryID = @AuditEntryID ";
                var data = await _connection.QueryAsync<AuditEntryPropertyQuery>(sql, new { AuditEntryID = auditLogId });
                data = data.Select(a => new AuditEntryPropertyQuery()
                {
                    AuditEntryPropertyID = a.AuditEntryPropertyID,
                    AuditEntryID = a.AuditEntryID,
                    PropertyName = a.PropertyName,
                    RelationName = a.RelationName,
                    OldValue = a.PropertyName != "PasswordHash" ? GetValue(_connection, a.NewValue) : "********",
                    NewValue = a.PropertyName != "PasswordHash" ? GetValue(_connection, a.NewValue) : "********"
                });
                return data.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private string GetValue(IDbConnection connection, string value)
        {
            var _value = string.Empty;
            try
            {
                if (string.IsNullOrEmpty(value))
                    _value = string.Empty;
                else if (value.Trim() == "True")
                    _value = "بلی";
                else if (value.Trim() == "False")
                    _value = "خیر";
                else if (value.Contains("SELECT"))
                    _value = _connection.Query<string>(value).FirstOrDefault();
                else
                    _value = value;
            }
            catch
            {
                _value = "خطا در ترجمه مقدار لاگ";
            }
            return _value;
        }

        public async Task<List<AuditEntryDto>> GetAuditLogByEntity(string entityName, long entityId)
        {
            try
            {
                var sql = @"
                    SELECT AuditEntryID, CreatedBy, pu.NationalCode, (pu.FirstName + ' ' + pu.LastName) AS FullName, (SELECT FORMAT(CreatedDate, 'yyyy/MM/dd-HH:mm:ss', 'fa')) AS CreatedDate, EntitySetName, 
                        (CASE WHEN [State] = 0 THEN N'ایجاد' WHEN [State] = 2 THEN N'ویرایش' ELSE N'حذف' END) AS StateName, EntityTypeName, [State] 
                    FROM AuditEntries ae 
                    INNER JOIN (
                        SELECT p.*, u.UserName FROM Persons p INNER JOIN AspNetUsers u ON p.Id = u.PersonId
                    ) pu ON ae.CreatedBy = pu.UserName
                    WHERE EntityTypeName = @EntityName and exists (
						select * from AuditEntryProperties where AuditEntryID = ae.AuditEntryID and PropertyName = 'Id' and (NewValue = @entityId or OldValue = @entityId)
					)
                    ORDER BY CreatedDate DESC";
                var data = await _connection.QueryAsync<AuditEntryDto>(sql, new { EntityName = entityName, EntityId = entityId });
                return data.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<ApiLogQuery>> GetApiLogAsync()
        {
            try
            {
                var sql = string.Empty;
                var orderBy = " ORDER BY RequestTime DESC ";
                var where = " WHERE [Path] = '/api/Security/Token' ";
                var roles = new UserResolverService(new HttpContextAccessor())?.GetRoles();
                sql = @" SELECT Id FROM AspNetRoles WHERE [Name] = @Name ";
                var defaultRoleId = await _connection.QueryFirstOrDefaultAsync<string>(sql, new { Name = DefaultRole });
                if (roles.Contains(defaultRoleId))
                    where = string.Empty;
                sql = @" 
                    select al.Id, (SELECT FORMAT(RequestTime, 'yyyy/MM/dd-HH:mm:ss', 'fa')) AS RequestTime, ResponseMillis, 
                        StatusCode, Method, Path, CreatedBy, pu.NationalCode, (pu.FirstName + ' ' + pu.LastName) AS FullName 
                        ,case when (StatusCode BETWEEN 200 AND 299) THEN 'موفق' Else 'ناموفق' END AS StatusName
                    from ApiLogs al
                    LEFT JOIN(
                        SELECT p.*, u.UserName FROM Persons p INNER JOIN AspNetUsers u ON p.Id = u.PersonId
                    ) pu ON al.CreatedBy = pu.UserName " + where + orderBy;
                var data = await _connection.QueryAsync<ApiLogQuery>(sql);
                return data.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<ApiLogQuery>> GetApiLogByFilterAsync(ApiLogFilter apiLogFilter)
        {
            try
            {
                var sql = string.Empty;
                var orderBy = " ORDER BY RequestTime DESC ";
                var where = " AND [Path] = '/api/Security/Token' ";
                var roles = new UserResolverService(new HttpContextAccessor())?.GetRoles();
                sql = @" SELECT Id FROM AspNetRoles WHERE [Name] = @Name ";
                var defaultRoleId = await _connection.QueryFirstOrDefaultAsync<string>(sql, new { Name = DefaultRole });
                if (roles.Contains(defaultRoleId))
                    where = string.Empty;
                sql = @" 
                    select al.Id, (SELECT FORMAT(RequestTime, 'yyyy/MM/dd-HH:mm:ss', 'fa')) AS RequestTime, ResponseMillis, 
                        StatusCode, Method, Path, CreatedBy, pu.NationalCode, (pu.FirstName + ' ' + pu.LastName) AS FullName 
                        ,case when (StatusCode BETWEEN 200 AND 299) THEN 'موفق' Else 'ناموفق' END AS StatusName
                    from ApiLogs al
                    LEFT JOIN(
                        SELECT p.*, u.UserName FROM Persons p INNER JOIN AspNetUsers u ON p.Id = u.PersonId
                    ) pu ON al.CreatedBy = pu.UserName 
                    WHERE (SELECT FORMAT(RequestTime, 'yyyy/MM/dd-HH:mm:ss', 'fa')) BETWEEN ISNULL(@FromDate, (SELECT FORMAT(RequestTime, 'yyyy/MM/dd-HH:mm:ss', 'fa'))) AND ISNULL(@ToDate, (SELECT FORMAT(RequestTime, 'yyyy/MM/dd-HH:mm:ss', 'fa')))
                    AND StatusCode = ISNULL(@StatusCode, StatusCode) AND Method = ISNULL(@Method, Method) AND [Path] = ISNULL(@Path, Path) 
                    AND ISNULL(CreatedBy, '') = ISNULL(null, ISNULL(CreatedBy, '')) AND ISNULL(NationalCode, '') = ISNULL(null, ISNULL(NationalCode, '')) " + where + orderBy;
                var data = await _connection.QueryAsync<ApiLogQuery>(sql, new { FromDate = apiLogFilter.FromDate, ToDate = apiLogFilter.ToDate, StatusCode = apiLogFilter.StatusCode, Method = apiLogFilter.Method, Path = apiLogFilter.Path, CreatedBy = apiLogFilter.CreatedBy, NationalCode = apiLogFilter.NationalCode });
                return data.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
