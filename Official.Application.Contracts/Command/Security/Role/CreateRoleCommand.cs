using System.Collections.Generic;

namespace Official.Application.Contracts.Command.Security.Role
{
    public class CreateRoleCommand : AppRoleDto
    {
        public List<long> UserIds { get; set; }
    }
}
