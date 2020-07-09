using System;
using System.Collections.Generic;
using System.Text;

namespace Official.Application.Contracts.Command.User
{
    public class LoginCommand : LoginDto
    {
        public bool? IsLogin { get; set; }
        public string Token { get; set; }
        public DateTime? Expiration { get; set; }
    }
}
