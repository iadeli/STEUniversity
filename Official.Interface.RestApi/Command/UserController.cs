using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Official.Application.Contracts.Command.Security.User;
using Official.Framework.Application;
using Official.Interface.Facade.Contracts.Utility;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static Official.Persistence.EFCore.Utility.Constant;

namespace Official.Interface.RestApi.Command
{
    [ApiController, Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ICommandBus _bus;
        public UserController(ICommandBus bus)
        {
            _bus = bus;
        }

        /// <summary>
        /// ایجاد کاربر
        /// </summary>
        /// <param name="command">پارامترهای ورودی</param>
        /// <returns></returns>
        [HttpPost, Authorize(Policy = Add)]
        public async Task<IActionResult> CreateUser(CreateUserCommand command)
        {
            try
            {
                var result = await _bus.Dispatch<CreateUserCommand, long>(command);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.ExpectationFailed, e.GetAllMessages());
            }
        }

        /// <summary>
        /// ویرایش کاربر
        /// </summary>
        /// <param name="command">پارامترهای ورودی</param>
        /// <returns></returns>
        [HttpPut, Authorize(Policy = Edit)]
        public async Task<IActionResult> UpdateUser(UpdateUserCommand command)
        {
            try
            {
                var result = await _bus.Dispatch<UpdateUserCommand, long>(command);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.ExpectationFailed, e.GetAllMessages());
            }
        }

        /// <summary>
        /// حذف کاربر
        /// </summary>
        /// <param name="id">شناسه کاربر</param>
        /// <returns></returns>
        [HttpDelete("{id}"), Authorize(Policy = Delete)]
        public async Task<IActionResult> RemoveUser(long id)
        {
            try
            {
                var command = new RemoveUserCommand() { Id = id };
                var result = await _bus.Dispatch<RemoveUserCommand, int>(command);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.ExpectationFailed, e.GetAllMessages());
            }
        }

    }
}
