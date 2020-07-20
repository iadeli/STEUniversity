using System;
using System.Collections.Generic;
using System.Text;

namespace Official.Application.Contracts.Command.Security
{
    public class AppRoleDto
    {
        public long Id { get; private set; }
        public string Name { get; set; }
        public string NormalizedName { get; private set; }
        public string ConcurrencyStamp { get; private set; }
    }
}
