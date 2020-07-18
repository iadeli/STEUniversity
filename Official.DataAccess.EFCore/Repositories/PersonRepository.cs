﻿using System;
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
                var person = await _context.Persons.FindAsync(id);
                person.BirthCertificate = await _context.BirthCertificates.Where(a => a.PersonId == id).FirstOrDefaultAsync();
                person.PersonDetail = await _context.PersonDetails.Where(a => a.PersonId == id).FirstOrDefaultAsync();
                person.Contact = await _context.Contacts.Where(a => a.PersonId == id).FirstOrDefaultAsync();
                return person;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> IsExistsTeacherCodeAsync(Person person, int action)
        {
            try
            {
                if (action == 1)                
                    return await _context.Persons.Where(a => a.TeacherCode == person.TeacherCode).AnyAsync();
                
                return await _context.Persons.Where(a => a.Id != person.Id && a.TeacherCode == person.TeacherCode).AnyAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> IsExistsNationalCodeAsync(Person person, int action)
        {
            try
            {
                if (action == 1)                
                    return await _context.Persons.Where(a => a.NationalCode == person.NationalCode).AnyAsync();
                
                return await _context.Persons.Where(a => a.Id != person.Id && a.NationalCode == person.NationalCode).AnyAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> IsExistsPersonalCodeAsync(Person person, int action)
        {
            try
            {
                if (action == 1)                
                    return await _context.Persons.Where(a => a.PersonnelCode == person.PersonnelCode).AnyAsync();
                
                return await _context.Persons.Where(a => a.Id != person.Id && a.PersonnelCode == person.PersonnelCode).AnyAsync();
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
                Person person = await GetById(id);
                _context.Persons.Remove(person);
                return await Save();
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
