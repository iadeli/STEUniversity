using System;
using System.Collections.Generic;
using System.Text;

namespace Official.Application.Contracts.Command.Security
{
    public class CreateRoleCommand : AppRoleDto
    {
        public List<long> UserIds { get; set; }
    }
}
