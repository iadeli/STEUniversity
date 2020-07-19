using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Official.Application.Attribute;
using Official.Application.Contracts.Command.Term;
using Official.Framework.Application;
using Official.Interface.Facade.Contracts.Utility;
using static Official.Persistence.EFCore.Utility.Constant;

namespace Official.Interface.RestApi.Command
{
    [ApiController, Route("api/[controller]")]
    public class TermController : ControllerBase
    {
        private readonly ICommandBus _bus;
        public TermController(ICommandBus bus)
        {
            _bus = bus;
        }

        /// <summary>
        /// افزودن ترم آموزشی
        /// </summary>
        /// <param name="command">فیلد های ترم آموزشی</param>
        /// <returns></returns>
        [HttpPost, Authorize(Policy = Add)]
        public async Task<IActionResult> Post(CreateTermCommand command)
        {
            try
            {
                var result = await _bus.Dispatch<CreateTermCommand, long>(command);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.ExpectationFailed, e.GetAllMessages());
            }
        }

        /// <summary>
        /// ویرایش ترم آموزشی
        /// </summary>
        /// <param name="command">فیلدهای ترم آموزشی</param>
        /// <returns></returns>
        [HttpPut, Authorize(Policy = Edit)]
        public async Task<IActionResult> Put(UpdateTermCommand command)
        {
            try
            {
                var result = await _bus.Dispatch<UpdateTermCommand, long>(command);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.ExpectationFailed, e.GetAllMessages());
            }
        }

        /// <summary>
        /// حذف ترم آموزشی
        /// </summary>
        /// <param name="Id">شناسه ترم آموزشی</param>
        /// <returns></returns>
        [HttpDelete("{Id}"), Authorize(Policy = Delete)]
        public async Task<IActionResult> Remove(long Id)
        {
            try
            {
                var command = new DeleteTermCommand() { Id = Id };
                var result = await _bus.Dispatch<DeleteTermCommand, int>(command);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.ExpectationFailed, e.GetAllMessages());
            }
        }
    }
}
