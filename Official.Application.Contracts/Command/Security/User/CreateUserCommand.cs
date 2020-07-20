using Official.Application.Contracts.Command.Security.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Official.Application.Contracts.Command.User
{
    public class CreateUserCommand : UserDto
    {
        public string Password { get; set; }
        public new long PersonId { get; set; }
        public List<long> RoleIds { get; set; }
    }
}
