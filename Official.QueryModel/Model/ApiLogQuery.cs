using System;
using System.Collections.Generic;
using System.Text;
using Official.Application.Contracts.Command.Log.ApiLogItem;

namespace Official.QueryModel.Model
{
    public class ApiLogQuery : ApiLogDto
    {
        public new string RequestTime { get; set; }
    }
}
