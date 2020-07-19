using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Official.Application.Attribute;
using Official.Interface.Facade.Contracts.IFacadeQuery.Term;
using Official.Interface.Facade.Contracts.Utility;
using static Official.Persistence.EFCore.Utility.Constant;

namespace Official.Interface.RestApi.Query
{
    [ApiController, Route("api/[controller]")]
    public class TermQueryController : ControllerBase
    {
        private readonly ITermFacadeQuery _query;
        public TermQueryController(ITermFacadeQuery query)
        {
            _query = query;
        }

        /// <summary>
        /// دریافت ترم آموزشی
        /// </summary>
        /// <returns></returns>
        [HttpGet, Authorize(Policy = View)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var term = await _query.Get();
                return Ok(term);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.ExpectationFailed, e.GetAllMessages());
            }
        }

        /// <summary>
        /// دریافت ترم آموزشی براساس شناسه
        /// </summary>
        /// <param name="id">شناسه ترم آموزشی</param>
        /// <returns></returns>
        [HttpGet("{id}"), Authorize(Policy = View)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var term = await _query.GetById(id);
                return Ok(term);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.ExpectationFailed, e.GetAllMessages());
            }
        }
    }
}
