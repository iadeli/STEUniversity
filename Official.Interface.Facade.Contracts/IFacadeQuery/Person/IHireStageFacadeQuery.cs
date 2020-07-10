using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Official.QueryModel.Model;

namespace Official.Interface.Facade.Contracts.IFacadeQuery.Person
{
    public interface IHireStageFacadeQuery
    {
        Task<List<HireStageQuery>> Get();
        Task<HireStageQuery> GetById(int id);
    }
}
