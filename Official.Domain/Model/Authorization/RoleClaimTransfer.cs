using System;
using System.Collections.Generic;
using System.Text;

namespace Official.Domain.Model.Authorization
{
    public class ClaimTransfer
    {
        public long Id { get; set; }
        public long UserOrRoleId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
    }
}
