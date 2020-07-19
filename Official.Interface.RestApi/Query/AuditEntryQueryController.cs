using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Official.Interface.Facade.Contracts.Utility;
using Official.QueryModel.Model;
using Official.Interface.Facade.Contracts.IFacadeQuery.AuditEntry;
using Official.Application.Contracts.Command.Log.ApiLogItem;
using Microsoft.AspNetCore.Authorization;
using static Official.Persistence.EFCore.Utility.Constant;

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
        [HttpGet, Authorize(Policy = View)]
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
        [HttpPost, Authorize(Policy = View)]
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
        [HttpGet("{AuditLogId}"), Authorize(Policy = View)]
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

        /// <summary>
        /// دریافت رخداد درخواست ها
        /// </summary>
        /// <returns></returns>
        [HttpGet("ApiLog"), Authorize(Policy = View)]
        public async Task<IActionResult> GetApiLogAsync()
        {
            try
            {
                var apiLogs = await _query.GetApiLogAsync();
                return Ok(apiLogs);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.ExpectationFailed, e.GetAllMessages());
            }
        }

        /// <summary>
        /// دریافت رخداد درخواست ها براساس فیلتر
        /// </summary>
        /// <returns></returns>
        [HttpPost("ApiLog"), Authorize(Policy = View)]
        public async Task<IActionResult> GetApiLogByFilter(ApiLogFilter apiLogFilter)
        {
            try
            {
                var apiLogs = await _query.GetApiLogByFilterAsync(apiLogFilter);
                return Ok(apiLogs);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.ExpectationFailed, e.GetAllMessages());
            }
        }

    }
}
