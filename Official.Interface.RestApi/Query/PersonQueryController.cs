﻿using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Official.Application.Attribute;
using Official.Interface.Facade.Contracts.IFacadeQuery.Person;
using Official.Interface.Facade.Contracts.Utility;
using static Official.Persistence.EFCore.Utility.Constant;

namespace Official.Interface.RestApi.Query
{
    [ApiController, Route("api/[controller]")]
    public class PersonQueryController : ControllerBase
    {
        private readonly IPersonFacadeQuery _query;
        public PersonQueryController(IPersonFacadeQuery query)
        {
            _query = query;
        }

        /// <summary>
        /// دریافت اطلاعات فردی
        /// </summary>
        /// <returns></returns>
        [HttpGet, Authorize(Policy = View)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var person = await _query.Get();
                return Ok(person);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.ExpectationFailed, e.GetAllMessages());
            }
        }

        /// <summary>
        /// دریافت اطلاعات فردی براساس شناسه
        /// </summary>
        /// <param name="id">شناسه اطلاعات فردی</param>
        /// <returns></returns>
        [HttpGet("{id}"), Authorize(Policy = View)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var person = await _query.GetById(id);
                return Ok(person);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.ExpectationFailed, e.GetAllMessages());
            }
        }
    }
}
