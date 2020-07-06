using Microsoft.AspNetCore.Mvc;
using Official.Application.Attribute;
using Official.Interface.Facade.Contracts.IFacadeQuery.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Official.Interface.RestApi
{
    [ServiceFilter(typeof(LoggingActionFilter))]
    [Route("api/[controller]")]
    [ApiController]
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
                throw e;
            }
        }
    }
}
