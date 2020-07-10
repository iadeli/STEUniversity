using Microsoft.AspNetCore.Mvc;
using Official.Application.Attribute;
using Official.Interface.Facade.Contracts.IFacadeQuery.Person;
using Official.Interface.Facade.Contracts.Utility;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Official.Interface.RestApi
{
    [ApiController, Route("api/[controller]"), ServiceFilter(typeof(LoggingActionFilter))]
    public class HireStageQueryController : ControllerBase
    {
        private readonly IHireStageFacadeQuery _query;
        public HireStageQueryController(IHireStageFacadeQuery query)
        {
            _query = query;
        }

        /// <summary>
        /// دریافت وضعیت استخدامی
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var hireStages = await _query.Get();
                return Ok(hireStages);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.ExpectationFailed, e.GetAllMessages());
            }
        }

        /// <summary>
        /// دریافت وضعیت استخدامی براساس شناسه
        /// </summary>
        /// <param name="id">شناسه وضعیت استخدامی</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var hireStage = await _query.GetById(id);
                return Ok(hireStage);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.ExpectationFailed, e.GetAllMessages());
            }
        }
    }
}
