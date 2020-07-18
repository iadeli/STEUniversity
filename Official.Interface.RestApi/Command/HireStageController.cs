using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Official.Application.Attribute;
using Official.Application.Contracts.Command.HireStageCommand;
using Official.Framework.Application;
using Official.Interface.Facade.Contracts.Utility;

namespace Official.Interface.RestApi.Command
{
    [ApiController, Route("api/[controller]")]
    public class HireStageController : ControllerBase
    {
        private readonly ICommandBus _bus;
        public HireStageController(ICommandBus bus)
        {
            _bus = bus;
        }

        /// <summary>
        /// افزودن وضعیت استخدامی
        /// </summary>
        /// <param name="command">فیلد های وضعیت استخدامی</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(CreateHireStageCommand command)
        {
            try
            {
                var result = await _bus.Dispatch<CreateHireStageCommand, long>(command);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.ExpectationFailed, e.GetAllMessages());
            }
        }

        /// <summary>
        /// ویرایش وضعیت استخدامی
        /// </summary>
        /// <param name="command">فیلدهای وضعیت استخدامی</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Put(UpdateHireStageCommand command)
        {
            try
            {
                var result = await _bus.Dispatch<UpdateHireStageCommand, long>(command);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.ExpectationFailed, e.GetAllMessages());
            }
        }

        /// <summary>
        /// حذف وضعیت استخدامی
        /// </summary>
        /// <param name="Id">شناسه وضعیت استخدامی</param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(long Id)
        {
            try
            {
                var command = new DeleteHireStageCommand() { Id = Id };
                var result = await _bus.Dispatch<DeleteHireStageCommand, int>(command);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.ExpectationFailed, e.GetAllMessages());
            }
        }
    }
}
