using Official.QueryModel.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Official.Interface.Facade.Contracts.IFacadeQuery.Person
{
    public interface IPersonFacadeQuery
    {
        Task<List<PersonQuery>> Get();
        Task<PersonQuery> GetById(int id);
    }
}
