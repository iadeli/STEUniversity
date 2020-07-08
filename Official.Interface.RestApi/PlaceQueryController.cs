﻿using Microsoft.AspNetCore.Authorization;
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

        /// <summary>
        /// دریافت لیست کشور، استان و شهر
        /// </summary>
        /// <param name="typeId">نوع لیست 1- کشور 2- استان 3- شهر</param>
        /// <param name="placeId">شناسه پدر</param>
        /// <returns></returns>
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
