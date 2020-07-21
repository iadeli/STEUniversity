using System;
using System.Collections.Generic;
using System.Text;

namespace Official.Application.Contracts.Command.Security
{
    public class CreateRoleClaimDto : SecurityDto
    {
        public long RoleId { get; set; }
        public bool? ViewPolicy { get; set; }
        public bool? AddPolicy { get; set; }
        public bool? EditPolicy { get; set; }
        public bool? DeletePolicy { get; set; }
        public string Policy { get; set; }
    }

    public class CreateRoleClaimCommand
    {
        public List<CreateRoleClaimDto> CreateRoleClaimDtos { get; set; }
    }
}
