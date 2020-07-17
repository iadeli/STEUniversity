using System;
using System.Collections.Generic;
using System.Text;

namespace Official.Application.Contracts.Command.Log.ApiLog
{
    public class ApiLogDto
    {
        public string CreatedBy { get; set; }
        public DateTime RequestTime { get; set; }
        public long ResponseMillis { get; set; }
        public int StatusCode { get; set; }
        public string Method { get; set; }
        public string Path { get; set; }
        public string QueryString { get; set; }
        public string RequestBody { get; set; }
        public string ResponseBody { get; set; }
    }
}
