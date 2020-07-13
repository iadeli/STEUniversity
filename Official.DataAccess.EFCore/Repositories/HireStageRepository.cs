using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Official.Domain.Model.CommonEntity.HireStage;
using Official.Domain.Model.Person;
using Official.Domain.Model.Person.IHireStageRepository;
using Official.Persistence.EFCore.Context;

namespace Official.Persistence.EFCore.Repositories
{
    public class HireStageRepository : IHireStageRepository, IDisposable
    {
        private readonly STEDbContext _context;
        public HireStageRepository(STEDbContext context)
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

        public async Task<HireStage> Create(HireStage hireStage)
        {
            try
            {
                await _context.HireStages.AddAsync(hireStage);
                await Save();
                return hireStage;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<HireStage> Update(HireStage hireStage)
        {
            try
            {
                _context.Entry(hireStage).State = EntityState.Modified;
                await Save();
                return hireStage;
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
                var hireStage = await _context.HireStages.FindAsync(id);
                _context.HireStages.Remove(hireStage);
                await Save();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<HireStage> GetById(long id)
        {
            try
            {
                var hireStage = await _context.HireStages.FindAsync(id);
                return hireStage;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> IsExistsHireStage(HireStage hireStage, int action)
        {
            try
            {
                var isExists = await _context.HireStages.Where(a => a.Name == hireStage.Name).AnyAsync();
                if (action == 2)
                    isExists = await _context.HireStages.Where(a => a.Id != hireStage.Id && a.Name == hireStage.Name).AnyAsync();
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
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
