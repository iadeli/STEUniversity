using Official.Application.Contracts.Command.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Official.Application.Contracts.Command.Security.User
{
    public class UpdateUserCommand : UserDto
    {
        public new long Id { get; set; }
        public string Password { get; private set; }
        public List<long> RoleIds { get; set; }
    }
}
