using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Official.Persistence.EFCore.Utility.Constant;

namespace Official.Persistence.EFCore.Utility
{
    public class UserResolverService
    {
        private readonly IHttpContextAccessor _context;
        public UserResolverService(HttpContextAccessor context)
        {
            _context = context;
        }

        public string GetUser()
        {
            return _context.HttpContext?.User?.Claims.FirstOrDefault(x => x.Properties.Where(p => p.Value == "sub").Any())?.Value; //userName
            //return _context.HttpContext?.User?.Identity?.Name; //personId
        }

        public List<string> GetRoles()
        {
            return _context.HttpContext?.User?.Claims.Where(x => x.Type == RoleType)?.Select(x => x.Value).ToList();
        }
    }
}
