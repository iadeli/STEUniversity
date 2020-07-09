using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Official.Application.Attribute;
using Official.Application.Contracts.Command.Person;
using Official.Framework.Application;
using Official.Interface.Facade.Contracts.Utility;

namespace Official.Interface.RestApi
{
    [ApiController, Route("api/[controller]"), ServiceFilter(typeof(LoggingActionFilter))]
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
        [HttpPost]
        public async Task<IActionResult> Post(CreatePersonCommand command)
        {
            try
            {
                var userId = this.User.Claims.FirstOrDefault(x => x.Type == "sub")?.Value;
                var result = await _bus.Dispatch(command);
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
        [HttpPut]
        public async Task<IActionResult> Put(UpdatePersonCommand command)
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

        /// <summary>
        /// حذف اطلاعات فردی
        /// </summary>
        /// <param name="Id">شناسه فرد</param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(long Id)
        {
            try
            {
                var command = DeletePersonCommand.Instance;
                command.Id = Id;
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
