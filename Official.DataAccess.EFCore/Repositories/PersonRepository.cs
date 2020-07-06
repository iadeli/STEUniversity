using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Official.Domain.Model.Person;
using Official.Domain.Model.Person.IPersonRepository;
using Official.Persistence.EFCore.Context;

namespace Official.Persistence.EFCore.Repositories
{
    public class PersonRepository : IPersonRepository, IDisposable
    {
        private readonly STEDbContext _context;
        public PersonRepository(STEDbContext context)
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

        public async Task<Person> Create(Person person)
        {
            try
            {
                await _context.AddAsync(person);
                await Save();
                return person;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Person> Update(Person person)
        {
            try
            {
                _context.Entry(person).State = EntityState.Modified;
                await Save();
                return person;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Person> GetById(long id)
        {
            try
            {
                return _context.Persons.Find(id);
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
                Person person = _context.Persons.Find(id);
                _context.Persons.Remove(person);
                await Save();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        //public async Task<List<Person>> Get()
        //{
        //    try
        //    {
        //        return _context.Persons.ToList();
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}

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
