using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Official.Domain.Model.Log.IApiLogRepository
{
    public interface IApiLogRepository : IDisposable
    {
        Task<ApiLog> Create(ApiLog apiLog);
    }
}
