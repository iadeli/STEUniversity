using System;
using System.Collections.Generic;
using System.Text;

namespace Official.Application.Contracts.Command.Log.ApiLog
{
    public class ApiLogDto
    {
        public string CreatedBy { get; set; }
        public DateTime RequestTime { get; private set; }
        public long ResponseMillis { get; private set; }
        public int StatusCode { get; set; }
        public string Method { get; set; }
        public string Path { get; set; }
        public string QueryString { get; private set; }
        public string RequestBody { get; private set; }
        public string ResponseBody { get; private set; }
    }
}
