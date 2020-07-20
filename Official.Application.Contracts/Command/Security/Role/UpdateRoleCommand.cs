using System;
using System.Collections.Generic;
using System.Text;

namespace Official.Application.Contracts.Command.Security.Role
{
    public class UpdateRoleCommand : AppRoleDto
    {
        public new long Id { get; set; }
        public List<long> UserIds { get; set; }
    }
}
