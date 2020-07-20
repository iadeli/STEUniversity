using Mapster;
using System;
using System.Collections.Generic;
using System.Text;

namespace Official.Application.Contracts.Command.Security.User
{
    public class UserDto
    {
        [AdaptIgnore]
        public long Id { get; private set; }
        [AdaptIgnore]
        public long PersonId { get; private set; }
        [AdaptIgnore]
        public string FullName { get; private set; }

        public string UserName { get; set; }
        [AdaptIgnore]
        public string NationalCode { get; private set; }
        [AdaptIgnore]
        public string Email { get; private set; }
        [AdaptIgnore]
        public string Mobile { get; private set; }
    }
}
