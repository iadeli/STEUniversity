using System;
using System.Collections.Generic;
using System.Text;

namespace Official.Application.Contracts.Command.AuditEntry
{
    public class AuditEntryPropertyDto
    {
        public int AuditEntryPropertyID { get; set; }
        public int AuditEntryID { get; set; }
        public string PropertyName { get; set; }
        public string RelationName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
    }
}
