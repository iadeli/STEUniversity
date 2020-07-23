using System;
using System.Collections.Generic;
using System.Text;

namespace Official.Application.Contracts.Command.Security.User
{
    public class CreateUserClaimDto : SecurityDto
    {
        public long UserId { get; set; }
        public string Policy { get; set; }
    }

    public class CreateUserClaimCommand
    {
        public List<CreateUserClaimDto> CreateUserClaimDtos { get; set; }
    }
}
