using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Official.Persistence.EFCore.Context;
using Official.Persistence.EFCore.Utility;
using static Official.Persistence.EFCore.Utility.Constant;

namespace Official.Interface.RestApi.PolicyHandler
{
    public class ManagePolicyHandler : AuthorizationHandler<ManageMPolicyRequirement>
    {
        private readonly STEDbContext _appDbContext;
        public ManagePolicyHandler(STEDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ManageMPolicyRequirement requirement)
        {

            var authFilterContext = context.Resource as AuthorizationFilterContext;
            if (authFilterContext == null) return Task.CompletedTask;

            var roles = ((ClaimsIdentity)context.User.Identity).Claims
                .Where(c => c.Type == RoleType)
                .Select(c => c.Value).ToList();

            //var userName = new UserResolverService(new HttpContextAccessor())?.GetUser();
            //var userId = _appDbContext.AspNetUsers.Where(a => a.UserName == userName).Select(a => a.Id).FirstOrDefault();
            var userId = ((ClaimsIdentity)context.User.Identity).Claims.Where(c => c.Type == UserType).Select(c => c.Value).FirstOrDefault();

            //var roleIdList = _appDbContext.Roles.Where(a => roles.Contains(a.Id.ToString())).Select(a => a.Id).ToList();
            var controller = authFilterContext.ActionDescriptor.GetType().GetProperty(ControllerProperty)?.GetValue(authFilterContext.ActionDescriptor, null);
            var action = authFilterContext.ActionDescriptor.GetType().GetProperty(ActionProperty)?.GetValue(authFilterContext.ActionDescriptor, null);
            var policy = authFilterContext.ActionDescriptor.EndpointMetadata.Where(a => a.GetType().Name == AuthorizeType && a.GetType().GetProperty(PolicyPostfix)?.GetValue(a, null) != null)
                .Select(a => a.GetType().GetProperty(PolicyPostfix)?.GetValue(a, null)).ToList();
            var actionInfoId = _appDbContext.ControllerInfos.Where(a => a.Controller == controller.ToString().Replace(ControllerPostfix2, "") && a.Action == action.ToString() && policy.Any(b => b == a.Policy)).Select(a => a.Id).SingleOrDefault();
            var isRoleAccess = _appDbContext.RoleClaims.Where(a => roles.Contains(a.RoleId.ToString()) && a.ClaimType == ControllerClaim && a.ClaimValue == actionInfoId.ToString()).Select(a => a.ClaimValue).Any();
            var isUserAccess = _appDbContext.UserClaims.Where(a => a.UserId.ToString() == userId && a.ClaimType == ControllerClaim && a.ClaimValue == actionInfoId.ToString()).Select(a => a.ClaimValue).Any();

            if (isRoleAccess || isUserAccess)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
