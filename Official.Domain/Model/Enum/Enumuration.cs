using Official.Domain.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Official.Domain.Model.Enum
{
    public sealed class Enumuration : AggregateRoot
    {
        public string EnumName { get; private set; }
        public string EnumTitle { get; private set; }
        public string EnumFiled { get; private set; }
        public string EnumValue { get; private set; }
    }
}
