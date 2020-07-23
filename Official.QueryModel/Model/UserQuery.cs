using Official.Application.Contracts.Command.Security.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Official.QueryModel.Model
{
    public class UserQuery : UserDto
    {
        public new long Id { get; set; }
        public new long PersonId { get; set; }
        public new string FullName { get; set; }
        public new string NationalCode { get; set; }
        public new string Email { get; set; }
        public new string Mobile { get; set; }
        public List<long> RoleIds { get; set; }
    }
}
