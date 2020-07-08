using Microsoft.AspNetCore.Mvc;
using Official.Application.Attribute;
using Official.Interface.Facade.Contracts.IFacadeQuery.Enum;
using Official.Interface.Facade.Contracts.Utility;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Official.Interface.RestApi
{
    [ServiceFilter(typeof(LoggingActionFilter))]
    [Route("api/[controller]")]
    [ApiController]
    public class EnumQueryController : ControllerBase
    {
        private readonly IEnumFacadeQuery _query;
        public EnumQueryController(IEnumFacadeQuery query)
        {
            _query = query;
        }

        /// <summary>
        /// دریافت لیست کمبو
        /// </summary>
        /// <param name="Name">نام کمبو</param>
        /// <returns></returns>
        [HttpGet("{Name}")]
        public async Task<IActionResult> GetByName(string Name)
        {
            try
            {
                var person = await _query.GetByName(Name);
                return Ok(person);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.ExpectationFailed, e.GetAllMessages());
            }
        }
    }
}
