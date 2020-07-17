using Official.Interface.Facade.Contracts.IFacadeQuery.AuditEntry;
using Official.QueryModel.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Linq;

namespace Official.Interface.Facade.Query.FacadeQuery.AuditEntry
{
    public class AuditEntryFacadeQuery : IAuditEntryFacadeQuery
    {
        private readonly IDbConnection _connection;
        public AuditEntryFacadeQuery(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<List<AuditEntryQuery>> GetAuditLogAsync()
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
                    ";
                var data = await _connection.QueryAsync<AuditEntryQuery>(sql);
                return data.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<AuditEntryQuery>> GetAuditLogByFilterAsync(AuditEntryQuery auditEntryQuery)
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
                     ";
                var data = await _connection.QueryAsync<AuditEntryQuery>(sql, new { CreatedBy = auditEntryQuery.CreatedBy, FromDate = auditEntryQuery.FromDate, ToDate = auditEntryQuery.ToDate, EntityTypeName = auditEntryQuery.EntityTypeName, State = auditEntryQuery.State, NationalCode = auditEntryQuery.NationalCode });
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
    }
}
