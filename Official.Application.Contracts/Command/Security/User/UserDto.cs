using System;
using System.Collections.Generic;
using System.Text;

namespace Official.Application.Contracts.Command.Security.User
{
    public class UserDto
    {
        public long Id { get; private set; }
        public long PersonId { get; private set; }
        public string FullName { get; private set; }
        public string UserName { get; set; }
        public string NationalCode { get; private set; }
        public string Email { get; private set; }
        public string Mobile { get; private set; }
    }
}
