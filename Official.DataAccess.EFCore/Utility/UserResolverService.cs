using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

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
            return _context.HttpContext?.User?.Identity?.Name;
        }
    }
}
