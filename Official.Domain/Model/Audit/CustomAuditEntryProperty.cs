using System;
using System.Collections.Generic;
using System.Text;

namespace Official.Domain.Model.Audit
{
    public class CustomAuditEntryProperty : Z.EntityFramework.Plus.AuditEntryProperty
    {
        public string EnPropertyName { get; set; }
    }
}
