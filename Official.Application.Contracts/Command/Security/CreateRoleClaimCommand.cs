using System;
using System.Collections.Generic;
using System.Text;

namespace Official.Application.Contracts.Command.Person.PersonCommand
{
    public class CreateRoleClaimCommand : RoleClaimDto
    {
        public new List<string> ClaimValue { get; set; }
    }
}
