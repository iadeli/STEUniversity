using Microsoft.AspNetCore.Mvc;
using Official.Application.Attribute;
using Official.Interface.Facade.Contracts.IFacadeQuery.Enum;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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
                return StatusCode((int)HttpStatusCode.ExpectationFailed, e.Message);
            }
        }
    }
}
