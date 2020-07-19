using System;
using System.Collections.Generic;
using System.Text;
using Official.Application.Contracts.Command.Log.AuditEntry;

namespace Official.QueryModel.Model
{
    public class AuditEntryQuery : AuditEntryDto
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }
    }
}
