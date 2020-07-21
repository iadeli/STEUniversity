using System.Collections.Generic;

namespace Official.Application.Contracts.Command.Security.User
{
    public class CreateUserCommand : UserDto
    {
        public string Password { get; set; }
        public new long PersonId { get; set; }
        public List<long> RoleIds { get; set; }
    }
}
