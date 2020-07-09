using Microsoft.EntityFrameworkCore;
using Official.Domain.Model.Person;
using Official.Domain.Model.Person.EducationalInfoRepository;
using Official.Persistence.EFCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Official.Persistence.EFCore.Repositories
{
    public class EducationalInfoRepository : IEducationalInfoRepository, IDisposable
    {
        private readonly STEDbContext _context;
        public EducationalInfoRepository(STEDbContext context)
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

        public async Task<EducationalInfo> Create(EducationalInfo educationalInfo)
        {
            try
            {
                await _context.AddAsync(educationalInfo);
                await Save();
                return educationalInfo;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<EducationalInfo> Update(EducationalInfo educationalInfo)
        {
            try
            {
                _context.Entry(educationalInfo).State = EntityState.Modified;
                await Save();
                return educationalInfo;
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
                var educationalInfo = _context.EducationalInfos.Find(id);
                _context.EducationalInfos.Remove(educationalInfo);
                await Save();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public EducationalInfo GetById(long id)
        {
            try
            {
                var educationalInfo = _context.EducationalInfos.Find(id);
                return educationalInfo;
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
