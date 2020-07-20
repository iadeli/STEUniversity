using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Official.Interface.Facade.Contracts.IFacadeQuery.Security.User;
using Official.Interface.Facade.Contracts.Utility;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static Official.Persistence.EFCore.Utility.Constant;

namespace Official.Interface.RestApi.Query
{
    [ApiController, Route("api/[controller]")]
    public class UserQueryController : ControllerBase
    {
        private readonly IUserFacadeQuery _query;
        public UserQueryController(IUserFacadeQuery query)
        {
            _query = query;
        }

        [HttpGet, Authorize(Policy = View)]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = await _query.GetUsers();
                return Ok(users);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.ExpectationFailed, e.GetAllMessages());
            }
        }
    }
}
