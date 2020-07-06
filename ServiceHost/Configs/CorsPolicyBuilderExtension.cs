using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace ServiceHost.Configs
{
    public static class CorsPolicyBuilderExtension
    {
        public static void Apply(this CorsPolicyBuilder builder, CorsOption options)
        {
            builder.WithHeaders(options.AllowedHeaders).WithMethods(options.AllowedMethods).WithOrigins(options.AllowedHosts);
        }
    }
}
