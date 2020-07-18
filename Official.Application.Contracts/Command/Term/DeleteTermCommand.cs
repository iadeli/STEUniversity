using System;
using System.Collections.Generic;
using System.Text;

namespace Official.Application.Contracts.Command.Term
{
    public class DeleteTermCommand : TermDto
    {
        public new long Id { get; set; }
    }
}
