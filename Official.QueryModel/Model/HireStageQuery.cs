using System;
using System.Collections.Generic;
using System.Text;
using Official.Application.Contracts.Command.HireStageCommand;

namespace Official.QueryModel.Model
{
    public class HireStageQuery : HireStageDto
    {
        public bool IsFacultymember { get; set; }
    }
}
