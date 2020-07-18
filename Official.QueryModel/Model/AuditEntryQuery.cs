using Official.Application.Contracts.Command.AuditEntry;
using System;
using System.Collections.Generic;
using System.Text;

namespace Official.QueryModel.Model
{
    public class AuditEntryQuery : AuditEntryDto
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }
    }
}
