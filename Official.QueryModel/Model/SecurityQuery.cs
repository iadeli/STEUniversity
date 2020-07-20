using System;
using System.Collections.Generic;
using System.Text;

namespace Official.QueryModel.Model
{
    public class SecurityQuery
    {
        public string ClaimType { get; set; }
        public long ClaimValue { get; set; }
        public string ClaimTitle { get; set; }
        public string Entity { get; set; }
        public bool Checked { get; set; }
    }
}
