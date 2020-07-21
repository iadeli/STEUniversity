using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Official.Application.Attribute;
using Official.Application.Contracts.Command.Person.PersonCommand;
using Official.Application.Contracts.Command.Security;
using Official.Framework.Application;
using Official.Interface.Facade.Contracts.Utility;
using static Official.Persistence.EFCore.Utility.Constant;

namespace Official.Interface.RestApi.Command
{
    [ApiController, Route("api/[controller]")]
    public class SecurityController : ControllerBase
    {
        private readonly ICommandBus _bus;
        public SecurityController(ICommandBus bus)
        {
            _bus = bus;
        }

        /// <summary>
        /// احراز هویت
        /// </summary>
        /// <param name="command">پارامترهای ورودی</param>
        /// <returns></returns>
        [HttpPost("Token"), AllowAnonymous]
        public async Task<IActionResult> Login(LoginCommand command)
        {
            try
            {
                //var userId = this.User.Claims.FirstOrDefault(x => x.Type == "sub")?.Value;
                var result = await _bus.Dispatch<LoginCommand, JwtTokenDto>(command);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.ExpectationFailed, e.GetAllMessages());
            }
        }

        /// <summary>
        /// تمدید توکن
        /// </summary>
        /// <param name="command">پارامترهای ورودی</param>
        /// <returns></returns>
        [HttpPost("Token/Refresh"), AllowAnonymous]
        public async Task<IActionResult> RefreshToken(string token)
        {
            try
            {
                var result = await _bus.Dispatch<string, JwtTokenDto>(token);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.ExpectationFailed, e.GetAllMessages());
            }
        }

        /// <summary>
        /// ایجاد دسترسی گروه به فرم ها
        /// </summary>
        /// <param name="command">پارامترهای ورودی</param>
        /// <returns></returns>
        [HttpPost("Role/Claim")]
        public async Task<IActionResult> CreateRoleClaim(CreateRoleClaimCommand command)
        {
            try
            {
                var result = await _bus.Dispatch<CreateRoleClaimCommand, bool>(command);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.ExpectationFailed, e.GetAllMessages());
            }
        }

    }
}
