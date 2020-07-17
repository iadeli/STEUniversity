using Official.Domain.Model.Log;
using Official.Domain.Model.Log.IApiLogRepository;
using Official.Persistence.EFCore.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Official.Persistence.EFCore.Repositories
{
    public class ApiLogRepository : IApiLogRepository
    {
        private readonly STEDbContext _context;
        public ApiLogRepository(STEDbContext context)
        {
            _context = context;
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<ApiLog> Create(ApiLog apiLog)
        {
            try
            {
                await _context.AddAsync(apiLog);
                await Save();
                return apiLog;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private async Task Save()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
