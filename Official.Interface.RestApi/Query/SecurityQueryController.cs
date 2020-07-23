using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Official.Interface.Facade.Contracts.IFacadeQuery.Security;
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
    public class SecurityQueryController : ControllerBase
    {
        private readonly ISecurityFacadeQuery _query;
        public SecurityQueryController(ISecurityFacadeQuery query)
        {
            _query = query;
        }

        /// <summary>
        /// دریافت دسترسی کاربر به استان و سمت
        /// </summary>
        /// <param name="type">ProvinceId - PositionId</param>
        /// <returns></returns>
        [HttpGet("UserClaim/{userId}/{type}"), Authorize(Policy = View)]
        public async Task<IActionResult> GetUserAccessClaim(long userId, string type)
        {
            try
            {
                var userClaim = await _query.GetUserClaim(userId, type);
                return Ok(userClaim);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.ExpectationFailed, e.GetAllMessages());
            }
        }

        /// <summary>
        /// دریافت دسترسی گروه به فرم ها
        /// </summary>
        /// <param name="type">ControllerInfoId</param>
        /// <returns></returns>
        [HttpGet("RoleClaim/{roleId}/{type}"), Authorize(Policy = View)]
        public async Task<IActionResult> GetRoleAccessClaim(long roleId, string type)
        {
            try
            {
                var roleClaim = await _query.GetRoleClaim(roleId, type);
                return Ok(roleClaim);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.ExpectationFailed, e.GetAllMessages());
            }
        }

    }
}