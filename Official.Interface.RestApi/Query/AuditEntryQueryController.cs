using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Official.Interface.Facade.Contracts.Utility;
using Official.QueryModel.Model;
using Official.Interface.Facade.Contracts.IFacadeQuery.AuditEntry;

namespace Official.Interface.RestApi.Query
{
    //[ServiceFilter(typeof(LoggingActionFilter))]
    [ApiController, Route("api/[controller]")]
    public class AuditEntryQueryController : ControllerBase
    {
        private readonly IAuditEntryFacadeQuery _query;
        public AuditEntryQueryController(IAuditEntryFacadeQuery query)
        {
            _query = query;
        }

        /// <summary>
        /// دریافت رخداد فرم ها
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAuditLog()
        {
            try
            {
                var auditLog = await _query.GetAuditLogAsync();
                return Ok(auditLog);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.ExpectationFailed, e.GetAllMessages());
            }
        }

        /// <summary>
        /// دریافت رخداد فرم ها براساس فیلتر
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> GetAuditLogByFilter(AuditEntryQuery auditEntryQuery)
        {
            try
            {
                var auditLog = await _query.GetAuditLogByFilterAsync(auditEntryQuery);
                return Ok(auditLog);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.ExpectationFailed, e.GetAllMessages());
            }
        }

        /// <summary>
        /// دریافت جزئیات رخداد فرم ها
        /// </summary>
        /// <returns></returns>
        [HttpGet("{AuditLogId}")]
        public async Task<IActionResult> GetPropertyAuditLog(int AuditLogId)
        {
            try
            {
                var propertyAuditLog = await _query.GetPropertyAuditLogAsync(AuditLogId);
                return Ok(propertyAuditLog);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.ExpectationFailed, e.GetAllMessages());
            }
        }
    }
}
