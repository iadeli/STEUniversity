using System;
using System.Collections.Generic;
using System.Text;

namespace Official.Application.Contracts.Command.Person.HistoryEducationalCommand
{
    public class UpdateHistoryEducationalCommand : HistoryEducationalDto
    {
        public new long Id { get; set; }
    }
}
