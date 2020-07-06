using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Official.Application.Attribute;
using Official.Application.Contracts.Command.User;
using Official.Framework.Application;
using Official.Interface.Facade.Contracts.Utility;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Official.Interface.RestApi
{
    [ServiceFilter(typeof(LoggingActionFilter))]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ICommandBus _bus;
        public UserController(ICommandBus bus)
        {
            _bus = bus;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginCommand command)
        {
            try
            {
                //var userId = this.User.Claims.FirstOrDefault(x => x.Type == "sub")?.Value;
                var result = await _bus.Dispatch(command);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.ExpectationFailed, e.GetAllMessages());
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserCommand command)
        {
            try
            {
                var result = await _bus.Dispatch(command);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.ExpectationFailed, e.GetAllMessages());
            }
        }
    }
}
