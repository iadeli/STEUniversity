using Official.QueryModel.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Official.Interface.Facade.Contracts.IFacadeQuery.Person
{
    public interface IEducationalInfoFacadeQuery
    {
        Task<List<EducationalInfoQuery>> Get();
        Task<EducationalInfoQuery> GetById(long id);
        Task<List<EducationalInfoQuery>> GetByPersonId(long personId);
    }
}
