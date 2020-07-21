using Official.Application.Contracts.Command.Security;
using System;
using System.Collections.Generic;
using System.Text;

namespace Official.QueryModel.Model
{
    public class UserAccessQuery : SecurityDto
    {
        public long UserId { get; set; }
    }
}
