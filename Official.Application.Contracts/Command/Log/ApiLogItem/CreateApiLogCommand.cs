using System;
using System.Collections.Generic;
using System.Text;

namespace Official.Application.Contracts.Command.Log.ApiLog
{
    public class CreateApiLogCommand : ApiLogDto
    {
        public new DateTime RequestTime { get; set; }
        public new long ResponseMillis { get; set; }
        public new string QueryString { get; set; }
        public new string RequestBody { get; set; }
        public new string ResponseBody { get; set; }
    }
}
