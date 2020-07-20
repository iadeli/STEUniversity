using System;
using System.Collections.Generic;
using System.Text;

namespace Official.Domain.Model.Security
{
    public class AppUserTransfer
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public long PersonId { get; set; }
        public List<long> RoleIds { get; set; }
    }
}
