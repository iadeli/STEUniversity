using System;
using System.Collections.Generic;
using System.Text;

namespace Official.Application.Contracts.Command.Enum
{
    public class PlaceDto
    {
        public long PlaceId { get; private set; }
        public int Type { get; private set; }
        public string Name { get; private set; }
    }
}
