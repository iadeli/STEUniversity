using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Official.Application.Contracts.Command.Security;
using Official.Application.Contracts.Command.Security.Role;
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
    public class RoleController : ControllerBase
    {
        private readonly ICommandBus _bus;
        public RoleController(ICommandBus bus)
        {
            _bus = bus;
        }

        /// <summary>
        /// ایجاد گروه
        /// </summary>
        /// <param name="command">پارامترهای ورودی</param>
        /// <returns></returns>
        [HttpPost, Authorize(Policy = Add)]
        public async Task<IActionResult> Create(CreateRoleCommand command)
        {
            try
            {
                var result = await _bus.Dispatch<CreateRoleCommand, long>(command);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.ExpectationFailed, e.GetAllMessages());
            }
        }

        /// <summary>
        /// ویرایش گروه
        /// </summary>
        /// <param name="command">پارامترهای ورودی</param>
        /// <returns></returns>
        [HttpPut, Authorize(Policy = Edit)]
        public async Task<IActionResult> Update(UpdateRoleCommand command)
        {
            try
            {
                var result = await _bus.Dispatch<UpdateRoleCommand, long>(command);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.ExpectationFailed, e.GetAllMessages());
            }
        }

        /// <summary>
        /// حذف گروه
        /// </summary>
        /// <param name="id">شناسه گروه</param>
        /// <returns></returns>
        [HttpDelete("{id}"), Authorize(Policy = Delete)]
        public async Task<IActionResult> RemoveUser(long id)
        {
            try
            {
                var command = new RemoveRoleCommand() { Id = id };
                var result = await _bus.Dispatch<RemoveRoleCommand, int>(command);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.ExpectationFailed, e.GetAllMessages());
            }
        }
    }
}
