using System;
using System.Collections.Generic;
using System.Text;

namespace Official.Application.Contracts.Command.Term
{
    public class TermDto
    {
        public long Id { get; set; }
        public int No { get; set; }
        public string FromYear { get; set; }
        public string ToYear { get; set; }
        public string Title { get; set; }
    }
}
