using System;
using System.Collections.Generic;
using System.Text;

namespace Official.Application.Contracts.Command.Security.User
{
    public class RemoveUserCommand : UserDto 
    {
        public new long Id { get; set; }
    }
}
