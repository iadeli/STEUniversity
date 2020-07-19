using System;
using System.Collections.Generic;
using System.Text;

namespace Official.Domain.Model.Authorization
{
    public class RoleClaimTransfer
    {
        public long Id { get; set; }
        public long RoleId { get; set; }
        public string ClaimType { get; set; }
        public new List<string> ClaimValue { get; private set; }
    }
}
