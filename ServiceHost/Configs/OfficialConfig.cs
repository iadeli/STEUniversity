using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceHost.Configs
{
    public class OfficialConfig
    {
        public CorsOption CorsOption { get; set; }
        public ConnectionStringCollection ConnectionStrings { get; set; }
    }

    public class ConnectionStringCollection
    {
        public string MainDbConnection { get; set; }
    }

    public class CorsOption
    {
        public string AllowedHosts { get; set; }
        public string AllowedMethods { get; set; }
        public string AllowedHeaders { get; set; }
    }

}
