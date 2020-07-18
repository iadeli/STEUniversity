using Official.Domain.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Official.Domain.Model.Authorization
{
    public class ControllerInfo : AggregateRoot
    {
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Policy { get; set; }
    }
}
