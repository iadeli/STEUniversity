using System;
using System.Collections.Generic;
using System.Text;

namespace Official.Application.Contracts.Command.User
{
    public class LoginDto
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
