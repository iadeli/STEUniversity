using Official.QueryModel.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Official.Interface.Facade.Contracts.IFacadeQuery.Person
{
    public interface IHistoryEducationalFacadeQuery
    {
        Task<List<HistoryEducationalQuery>> GetAsync();
        Task<HistoryEducationalQuery> GetByIdAsync(int id);
    }
}
