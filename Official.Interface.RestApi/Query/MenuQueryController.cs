﻿using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Official.Application.Attribute;
using Official.Interface.Facade.Contracts.IFacadeQuery.Menu;
using Official.Interface.Facade.Contracts.Utility;
using static Official.Persistence.EFCore.Utility.Constant;

namespace Official.Interface.RestApi.Query
{
    [ApiController, Route("api/[controller]")]
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
        [HttpGet, Authorize(Policy = View)]
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
        [HttpGet("Tree"), Authorize(Policy = View)]
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
