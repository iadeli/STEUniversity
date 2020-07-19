using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Official.Application.Attribute;
using Official.Application.Contracts.Command.Person.PersonCommand;
using Official.Framework.Application;
using Official.Interface.Facade.Contracts.Utility;
using static Official.Persistence.EFCore.Utility.Constant;

namespace Official.Interface.RestApi.Command
{
    [ApiController, Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ICommandBus _bus;
        public PersonController(ICommandBus bus)
        {
            _bus = bus;
        }

        /// <summary>
        /// افزودن اطلاعات فردی
        /// </summary>
        /// <param name="command">فیلدهای اطلاعات فردی</param>
        /// <returns></returns>
        [HttpPost, Authorize(Policy = Add)]
        public async Task<IActionResult> Post(CreatePersonCommand command)
        {
            try
            {
                var userId = this.User.Claims.FirstOrDefault(x => x.Type == "sub")?.Value;
                var result = await _bus.Dispatch<CreatePersonCommand, long>(command);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.ExpectationFailed, e.GetAllMessages());
            }
        }

        /// <summary>
        /// ویرایش اطلاعات فردی
        /// </summary>
        /// <param name="command">فیلدهای اطلاعات فردی</param>
        /// <returns></returns>
        [HttpPut, Authorize(Policy = Edit)]
        public async Task<IActionResult> Put(UpdatePersonCommand command)
        {
            try
            {
                var result = await _bus.Dispatch<UpdatePersonCommand, long>(command);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.ExpectationFailed, e.GetAllMessages());
            }
        }

        /// <summary>
        /// حذف اطلاعات فردی
        /// </summary>
        /// <param name="Id">شناسه فرد</param>
        /// <returns></returns>
        [HttpDelete("{Id}"), Authorize(Policy = Delete)]
        public async Task<IActionResult> Remove(long Id)
        {
            try
            {
                var command = new DeletePersonCommand() { Id = Id };
                var result = await _bus.Dispatch<DeletePersonCommand, int>(command);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.ExpectationFailed, e.GetAllMessages());
            }
        }
    }
}
