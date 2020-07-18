using Official.Application.Contracts.Command.Log.ApiLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Official.Application.Contracts.Command.Log.ApiLogItem
{
    public class ApiLogFilter : ApiLogDto
    {
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string NationalCode { get; set; }
        public new int? StatusCode { get; set; }
    }
}
