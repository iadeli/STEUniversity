using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Official.Application.Attribute;
using Official.Interface.Facade.Contracts.IFacadeQuery.Enum;
using Official.Interface.Facade.Contracts.Utility;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Official.Persistence.EFCore.Jwt;

namespace Official.Interface.RestApi
{
    [ServiceFilter(typeof(LoggingActionFilter))]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PlaceQueryController : ControllerBase
    {
        private readonly IPlaceFacadeQuery _query;
        public PlaceQueryController(IPlaceFacadeQuery query)
        {
            _query = query;
        }

        [HttpGet("{typeId}/{placeId?}")]
        public async Task<IActionResult> GetByType(int typeId, long? placeId = null)
        {
            try
            {
                var places = await _query.GetByType(typeId, placeId);
                return Ok(places);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.ExpectationFailed, e.GetAllMessages());
            }
        }
    }
}
