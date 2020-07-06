using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Official.Domain.Model.Person.IPersonRepository
{
    public interface IPersonRepository : IDisposable
    {
        Task<Person> Create(Person person);
        Task<Person> Update(Person person);
        Task Remove(long id);

        Task<Person> GetById(long id);
        //Task<List<Person>> Get();
    }
}
