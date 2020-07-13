using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Official.Application.Attribute;
using Official.Interface.Facade.Contracts.IFacadeQuery.Person;
using Official.Interface.Facade.Contracts.Utility;

namespace Official.Interface.RestApi.Query
{
    [ApiController, Route("api/[controller]"), ServiceFilter(typeof(LoggingActionFilter))]
    public class HistoryEducationalQueryController : ControllerBase
    {
        private readonly IHistoryEducationalFacadeQuery _query;
        public HistoryEducationalQueryController(IHistoryEducationalFacadeQuery query)
        {
            _query = query;
        }

        /// <summary>
        /// دریافت سوابق تحصیلی
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var historyEducational = await _query.GetAsync();
                return Ok(historyEducational);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.ExpectationFailed, e.GetAllMessages());
            }
        }

        /// <summary>
        /// دریافت سوابق تحصیلی براساس شناسه
        /// </summary>
        /// <param name="id">شناسه سوابق تحصیلی</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var historyEducational = await _query.GetByIdAsync(id);
                return Ok(historyEducational);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.ExpectationFailed, e.GetAllMessages());
            }
        }
    }
}
