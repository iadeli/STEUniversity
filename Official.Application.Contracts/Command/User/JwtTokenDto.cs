using System;
using System.Collections.Generic;
using System.Text;

namespace Official.Application.Contracts.Command.User
{
    public class JwtTokenDto
    {
        public string Token { get; set; }
        public DateTime? Expiration { get; set; }
    }
}
