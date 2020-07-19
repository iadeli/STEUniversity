using System;
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
        [HttpGet, Authorize(Policy = View)]
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
        [HttpGet("{id}"), Authorize(Policy = View)]
        public async Task<IActionResult> GetById(long id)
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

        /// <summary>
        /// دریافت اطلاعات آموزشی براساس شناسه فرد
        /// </summary>
        /// <param name="personId">شناسه فرد</param>
        /// <returns></returns>
        [HttpGet("Person/{personId}"), Authorize(Policy = View)]
        public async Task<IActionResult> GetByPersonId(long personId)
        {
            try
            {
                var educationalInfo = await _query.GetByPersonId(personId);
                return Ok(educationalInfo);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.ExpectationFailed, e.GetAllMessages());
            }
        }
    }
}
