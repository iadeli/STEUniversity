using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Official.Application.Attribute;
using Official.Application.Contracts.Command.Term;
using Official.Framework.Application;
using Official.Interface.Facade.Contracts.Utility;

namespace Official.Interface.RestApi.Command
{
    [ApiController, Route("api/[controller]"), ServiceFilter(typeof(LoggingActionFilter))]
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
        [HttpPost]
        public async Task<IActionResult> Post(CreateTermCommand command)
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
        /// ویرایش ترم آموزشی
        /// </summary>
        /// <param name="command">فیلدهای ترم آموزشی</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Put(UpdateTermCommand command)
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
        /// حذف ترم آموزشی
        /// </summary>
        /// <param name="Id">شناسه ترم آموزشی</param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(long Id)
        {
            try
            {
                var command = new DeleteTermCommand(); //DeleteTermCommand.Instance;
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
