using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Official.Persistence.EFCore.Jwt
{
    public class MvsJwtTokens
    {
        public const string Issuer = "STEUniversity";
        public const string Audience = "ApiUser";
        public const string Key = "5022291067015139";

        public const string AuthSchemes = "Identity.Application" + "," + JwtBearerDefaults.AuthenticationScheme;
    }
}
