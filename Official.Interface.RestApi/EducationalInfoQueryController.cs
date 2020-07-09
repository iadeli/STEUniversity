﻿using Microsoft.AspNetCore.Mvc;
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
    public class EducationalInfoQueryController : ControllerBase
    {
        private readonly IEducationalInfoFacadeQuery _query;
        public EducationalInfoQueryController(IEducationalInfoFacadeQuery query)
        {
            _query = query;
        }

        /// <summary>
        /// دریافت اطلاعات آموزشی
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var educationalInfo = await _query.Get();
                return Ok(educationalInfo);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.ExpectationFailed, e.GetAllMessages());
            }
        }

        /// <summary>
        /// دریافت اطلاعات آموزشی براساس شناسه
        /// </summary>
        /// <param name="id">شناسه اطلاعات آموزشی</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var educationalInfo = await _query.GetById(id);
                return Ok(educationalInfo);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.ExpectationFailed, e.GetAllMessages());
            }
        }
    }
}