using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Official.Application.Attribute;
using Official.Interface.Facade.Contracts.IFacadeQuery.Menu;
using Official.Interface.Facade.Contracts.IFacadeQuery.Person;

namespace Official.Interface.RestApi
{
    [ServiceFilter(typeof(LoggingActionFilter))]
    [Route("api/[controller]")]
    [ApiController]
    public class MenuQueryController : ControllerBase
    {
        private readonly IMenuFacadeQuery _query;
        public MenuQueryController(IMenuFacadeQuery query)
        {
            _query = query;
        }

        public async Task<IActionResult> Get()
        {
            try
            {
                var menus = await _query.Get();
                return Ok(menus);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.ExpectationFailed, e.Message);
            }
        }

        [HttpGet("Tree")]
        public async Task<IActionResult> GetTree()
        {
            try
            {
                var tree = await _query.GetTree();
                return Ok(tree);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.ExpectationFailed, e.Message);
            }
        }
    }
}
