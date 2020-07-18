using System;
using System.Collections.Generic;
using System.Text;

namespace Official.Application.Contracts.Command.Person.HistoryEducationalCommand
{
    public class CreateHistoryEducationalCommand : HistoryEducationalDto
    {
        public new long PersonId { get; set; }
    }
}
