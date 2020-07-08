using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Official.Application.Attribute;
using Official.Interface.Facade.Contracts.IFacadeQuery.Person;
using Official.Interface.Facade.Contracts.Utility;
using Official.QueryModel.Model;

namespace Official.Interface.RestApi
{
    [ServiceFilter(typeof(LoggingActionFilter))]
    [Route("api/[controller]")]
    [ApiController]
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
        [HttpGet]
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
        [HttpGet("{id}")]
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
