using System;

namespace Official.Application.Contracts.Command.Security
{
    public class JwtTokenDto
    {
        public string Token { get; set; }
        public DateTime? Expiration { get; set; }
    }
}
