﻿using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Official.Application.Attribute;
using Official.Interface.Facade.Contracts.IFacadeQuery.Person;
using Official.Interface.Facade.Contracts.Utility;

namespace Official.Interface.RestApi.Query
{
    [ApiController, Route("api/[controller]")]
    public class HireStageQueryController : ControllerBase
    {
        private readonly IHireStageFacadeQuery _query;
        public HireStageQueryController(IHireStageFacadeQuery query)
        {
            _query = query;
        }

        /// <summary>
        /// دریافت وضعیت استخدامی
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var hireStages = await _query.Get();
                return Ok(hireStages);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.ExpectationFailed, e.GetAllMessages());
            }
        }

        /// <summary>
        /// دریافت وضعیت استخدامی براساس شناسه
        /// </summary>
        /// <param name="id">شناسه وضعیت استخدامی</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var hireStage = await _query.GetById(id);
                return Ok(hireStage);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.ExpectationFailed, e.GetAllMessages());
            }
        }

        /// <summary>
        /// دریافت وضعیت استخدامی براساس شناسه فرد
        /// </summary>
        /// <param name="PersonId">شناسه فرد</param>
        /// <returns></returns>
        [HttpGet("Person/{PersonId}")]
        public async Task<IActionResult> GetById(long PersonId)
        {
            try
            {
                var hireStage = await _query.GetByPersonId(PersonId);
                return Ok(hireStage);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.ExpectationFailed, e.GetAllMessages());
            }
        }

    }
}
