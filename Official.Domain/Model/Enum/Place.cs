using Official.Domain.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Official.Domain.Model.Enum
{
    public sealed class Place : Entity
    {
        public long PlaceId { get; set; }
        public int Type { get; private set; }
        public string Name { get; private set; }
    }
}
