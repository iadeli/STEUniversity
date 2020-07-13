using Official.QueryModel.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Official.Interface.Facade.Contracts.IFacadeQuery.AuditEntry
{
    public interface IAuditEntryFacadeQuery
    {
        Task<List<AuditEntryQuery>> GetAuditLogAsync();
        Task<List<AuditEntryQuery>> GetAuditLogByFilterAsync(AuditEntryQuery auditEntryQuery);
        Task<List<AuditEntryPropertyQuery>> GetPropertyAuditLogAsync(int auditLogId);

    }
}
