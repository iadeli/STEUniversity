using Official.Application.Contracts.Command.Security;
using System;
using System.Collections.Generic;
using System.Text;
using Official.Application.Contracts.Command.Security.Role;

namespace Official.QueryModel.Model
{
    public class RoleQuery : AppRoleDto
    {
        public new long Id { get; set; }
        public List<long> UserIds { get; set; }
    }
}
