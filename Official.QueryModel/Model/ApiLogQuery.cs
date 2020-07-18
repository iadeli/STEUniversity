using Official.Application.Contracts.Command.Log.ApiLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Official.QueryModel.Model
{
    public class ApiLogQuery : ApiLogDto
    {
        public new string RequestTime { get; set; }
    }
}
