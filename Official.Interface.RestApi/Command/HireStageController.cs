using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Official.Application.Attribute;
using Official.Application.Contracts.Command.Person.EducationalInfoCommand;
using Official.Application.Contracts.Command.Person.HireStageCommand;
using Official.Framework.Application;
using Official.Interface.Facade.Contracts.Utility;

namespace Official.Interface.RestApi
{
    [ApiController, Route("api/[controller]"), ServiceFilter(typeof(LoggingActionFilter))]
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
                var result = await _bus.Dispatch(command);
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
                var result = await _bus.Dispatch(command);
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
                var command = new DeleteHireStageCommand(); //DeleteHireStageCommand.Instance;
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
