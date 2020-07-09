using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Official.Application.Attribute;
using Official.Interface.Facade.Contracts.IFacadeQuery.Menu;
using Official.Interface.Facade.Contracts.IFacadeQuery.Person;
using Official.Interface.Facade.Contracts.Utility;

namespace Official.Interface.RestApi
{
    [ApiController, Route("api/[controller]"), ServiceFilter(typeof(LoggingActionFilter))]
    public class MenuQueryController : ControllerBase
    {
        private readonly IMenuFacadeQuery _query;
        public MenuQueryController(IMenuFacadeQuery query)
        {
            _query = query;
        }

        /// <summary>
        /// دریافت لیست منو
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var menus = await _query.Get();
                return Ok(menus);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.ExpectationFailed, e.GetAllMessages());
            }
        }

        /// <summary>
        /// دریافت ساختار درختی منو
        /// </summary>
        /// <returns></returns>
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
                return StatusCode((int)HttpStatusCode.ExpectationFailed, e.GetAllMessages());
            }
        }
    }
}
