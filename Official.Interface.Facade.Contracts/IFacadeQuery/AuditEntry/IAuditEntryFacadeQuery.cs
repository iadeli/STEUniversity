using Official.Application.Contracts.Command.Log.ApiLogItem;
using Official.QueryModel.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Official.Application.Contracts.Command.Log.AuditEntry;

namespace Official.Interface.Facade.Contracts.IFacadeQuery.AuditEntry
{
    public interface IAuditEntryFacadeQuery
    {
        Task<List<AuditEntryDto>> GetAuditLogAsync();
        Task<List<AuditEntryDto>> GetAuditLogByFilterAsync(AuditEntryQuery auditEntryQuery);
        Task<List<AuditEntryPropertyQuery>> GetPropertyAuditLogAsync(int auditLogId);

        Task<List<ApiLogQuery>> GetApiLogAsync();
        Task<List<ApiLogQuery>> GetApiLogByFilterAsync(ApiLogFilter apiLogFilter);
    }
}
