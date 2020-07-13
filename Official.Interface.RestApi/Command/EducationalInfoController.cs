using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Official.Application.Attribute;
using Official.Application.Contracts.Command.Person.EducationalInfoCommand;
using Official.Framework.Application;
using Official.Interface.Facade.Contracts.Utility;

namespace Official.Interface.RestApi.Command
{
    //[ServiceFilter(typeof(LoggingActionFilter))]
    [ApiController, Route("api/[controller]")]
    public class EducationalInfoController : ControllerBase
    {
        private readonly ICommandBus _bus;
        public EducationalInfoController(ICommandBus bus)
        {
            _bus = bus;
        }

        /// <summary>
        /// افزودن اطلاعات آموزشی
        /// </summary>
        /// <param name="command">فیلد های اطلاعات آموزشی</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(CreateEducationalInfoCommand command)
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
        /// ویرایش اطلاعات آموزشی
        /// </summary>
        /// <param name="command">فیلدهای اطلاعات آموزشی</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Put(UpdateEducationalInfoCommand command)
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
        /// حذف اطلاعات آموزشی
        /// </summary>
        /// <param name="Id">شناسه اطلاعات آموزشی</param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(long Id)
        {
            try
            {
                var command = new DeleteEducationalInfoCommand(); //DeleteEducationalInfoCommand.Instance;
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
