using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Official.Interface.Facade.Contracts.IFacadeQuery.Security.Role;
using Official.Interface.Facade.Contracts.IFacadeQuery.Security.User;
using Official.Interface.Facade.Contracts.Utility;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static Official.Persistence.EFCore.Utility.Constant;

namespace Official.Interface.RestApi.Query
{
    [ApiController, Route("api/[controller]")]
    public class RoleQueryController : ControllerBase
    {
        private readonly IRoleFacadeQuery _query;
        public RoleQueryController(IRoleFacadeQuery query)
        {
            _query = query;
        }

        /// <summary>
        /// دریافت گروه
        /// </summary>
        /// <returns></returns>
        [HttpGet, Authorize(Policy = View)]
        public async Task<IActionResult> GetRoles()
        {
            try
            {
                var roles = await _query.Get();
                return Ok(roles);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.ExpectationFailed, e.GetAllMessages());
            }
        }

        /// <summary>
        /// دریافت گروه براساس شناسه گروه
        /// </summary>
        /// <param name="roleId">شناسه گروه</param>
        /// <returns></returns>
        [HttpGet, Authorize(Policy = View)]
        public async Task<IActionResult> GetRoleById(long roleId)
        {
            try
            {
                var role = await _query.GetRoleByIdAsync(roleId);
                return Ok(role);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.ExpectationFailed, e.GetAllMessages());
            }
        }

        /// <summary>
        /// دریافت گروه براساس شناسه فرد
        /// </summary>
        /// <param name="PersonId"></param>
        /// <returns></returns>
        [HttpGet, Authorize(Policy = View)]
        public async Task<IActionResult> GetRoleByPersonId(long PersonId)
        {
            try
            {
                var users = await _query.GetRoleByPersonIdAsync(PersonId);
                return Ok(users);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.ExpectationFailed, e.GetAllMessages());
            }
        }

    }
}
