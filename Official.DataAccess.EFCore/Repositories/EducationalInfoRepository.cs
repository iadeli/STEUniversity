using Microsoft.EntityFrameworkCore;
using Official.Domain.Model.Person;
using Official.Persistence.EFCore.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Official.Domain.Model.Person.IEducationalInfoRepository;
using Z.EntityFramework.Plus;

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
                var educationalInfo = await _context.EducationalInfos.FindAsync(id);
                _context.EducationalInfos.Remove(educationalInfo);
                await Save();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<EducationalInfo> GetById(long id)
        {
            try
            {
                var educationalInfo = await _context.EducationalInfos.FindAsync(id);
                return educationalInfo;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> IsExistsEducationalInfo(EducationalInfo entity, int action)
        {
            try
            {
                var isExists = await _context.EducationalInfos.Where(a => a.TermId == entity.TermId && a.PersonId == entity.PersonId).AnyAsync();
                if(action == 2)
                    isExists = await _context.EducationalInfos.Where(a => a.Id != entity.Id && a.TermId == entity.TermId && a.PersonId == entity.PersonId).AnyAsync();
                return isExists;
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
                //var audit = new Audit();
                //audit.CreatedBy = "ZZZ Projects"; // Optional
                await _context.SaveChangesAsync();
                //var entries = audit.Entries;
                //foreach (var entry in entries)
                //{
                //    foreach (var property in entry.Properties)
                //    {
                //    }
                //}
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
