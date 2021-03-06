﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Official.Domain.Model.Person.IPersonRepository
{
    public interface IPersonRepository : IDatabaseTransaction, IDisposable
    {
        Task<Person> Create(Person person);
        Task<Person> Update(Person person);
        Task<int> Remove(long id);

        Task<Person> GetById(long id);
        Task<bool> IsExistsTeacherCodeAsync(Person person, int action);
        Task<bool> IsExistsNationalCodeAsync(Person person, int action);
        Task<bool> IsExistsPersonalCodeAsync(Person person, int action);
        List<Person> GetExistsPerson(List<Person> entities);
        Task UpdateRangeAsync(List<Person> existsPerson);
        Task CreateRangeAsync(List<Person> entities);
    }
}
