using Mapster;
using System;
using System.Collections.Generic;
using System.Text;

namespace Official.Application.Contracts.Command.Term
{
    public class TermDto
    {
        [AdaptIgnore]
        public long Id { get; private set; }
        public int No { get; set; }
        public string FromYear { get; set; }
        public string ToYear { get; set; }
        [AdaptIgnore]
        public string Title { get; private set; }
    }
}
