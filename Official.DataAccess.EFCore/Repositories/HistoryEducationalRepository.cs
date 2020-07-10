using Microsoft.EntityFrameworkCore;
using Official.Domain.Model.Person;
using Official.Domain.Model.Person.IHistoryEducationalRepository;
using Official.Persistence.EFCore.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Official.Persistence.EFCore.Repositories
{
    public class HistoryEducationalRepository : IHistoryEducationalRepository, IDisposable
    {
        private readonly STEDbContext _context;
        public HistoryEducationalRepository(STEDbContext context)
        {
            _context = context;
        }

        public async Task<HistoryEducational> Create(HistoryEducational historyEducational)
        {
            try
            {
                await _context.AddAsync(historyEducational);
                await Save();
                return historyEducational;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<HistoryEducational> GetById(long id)
        {
            try
            {
                var historyEducational = await _context.HistoryEducationals.FindAsync(id);
                return historyEducational;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task Remove(long id)
        {
            try
            {
                var historyEducational = await _context.HistoryEducationals.FindAsync(id);
                _context.HistoryEducationals.Remove(historyEducational);
                await Save();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<HistoryEducational> Update(HistoryEducational historyEducational)
        {
            try
            {
                _context.Entry(historyEducational).State = EntityState.Modified;
                await Save();
                return historyEducational;
            }
            catch (Exception e)
            {
                throw e;
            }
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
