using System;
using System.Collections.Generic;
using System.Text;

namespace Official.Application.Contracts.Command.AuditEntry
{
    public class AuditEntryDto
    {
        public int AuditEntryID { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string EntitySetName { get; set; }
        public string EntityTypeName { get; set; }
        public int State { get; set; }
        public string StateName { get; set; }

        public string FromDate { get; set; }
        public string ToDate { get; set; }
    }
}
