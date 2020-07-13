using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Official.Application.Attribute;
using Official.Application.Contracts.Command.Person.HistoryEducationalCommand;
using Official.Framework.Application;
using Official.Interface.Facade.Contracts.Utility;

namespace Official.Interface.RestApi.Command
{
    [ApiController, Route("api/[controller]")]
    public class HistoryEducationalController : ControllerBase
    {
        private readonly ICommandBus _bus;
        public HistoryEducationalController(ICommandBus bus)
        {
            _bus = bus;
        }

        /// <summary>
        /// افزودن سوابق تحصیلی
        /// </summary>
        /// <param name="command">فیلدهای سوابق تحصیلی</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(CreateHistoryEducationalCommand command)
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
        /// ویرایش سوابق تحصیلی
        /// </summary>
        /// <param name="command">فیلدهای سوابق تحصیلی</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Put(UpdateHistoryEducationalCommand command)
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
        /// حذف سوابق تحصیلی
        /// </summary>
        /// <param name="Id">شناسه سوابق تحصیلی</param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(long Id)
        {
            try
            {
                var command = new DeleteHistoryEducationalCommand(); //DeleteHistoryEducationalCommand.Instance;
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
