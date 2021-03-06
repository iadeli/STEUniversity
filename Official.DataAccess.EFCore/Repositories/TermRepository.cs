﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Official.Domain.Model.CommonEntity.Term;
using Official.Domain.Model.CommonEntity.Term.ITermRepository;
using Official.Persistence.EFCore.Context;

namespace Official.Persistence.EFCore.Repositories
{
    public class TermRepository : ITermRepository
    {
        private readonly STEDbContext _context;
        public TermRepository(STEDbContext context)
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

        public async Task<Term> Create(Term term)
        {
            try
            {
                await _context.AddAsync(term);
                await Save();
                return term;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Term> Update(Term term)
        {
            try
            {
                _context.Entry(term).State = EntityState.Modified;
                await Save();
                return term;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> Remove(long id)
        {
            try
            {
                var term = await _context.Terms.FindAsync(id);
                _context.Remove(term);
                return await Save();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Term> GetById(long id)
        {
            try
            {
                var term = await _context.Terms.FindAsync(id);
                return term;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> IsExistsTerm(Term term, int action)
        {
            try
            {
                var isExistsTerm = await _context.Terms.Where(a => a.No == term.No && a.FromYear == term.FromYear).AnyAsync();
                if(action == 2)
                    isExistsTerm = await _context.Terms.Where(a => a.Id != term.Id && a.No == term.No && a.FromYear == term.FromYear).AnyAsync();
                return isExistsTerm;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private async Task<int> Save()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
