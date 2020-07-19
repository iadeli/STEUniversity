using System;
using System.Collections.Generic;
using System.Text;

namespace Official.Application.Contracts.Command.Person.PersonCommand
{
    public class RoleClaimDto
    {
        public long Id { get; set; }
        public long RoleId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; private set; }
    }
}
