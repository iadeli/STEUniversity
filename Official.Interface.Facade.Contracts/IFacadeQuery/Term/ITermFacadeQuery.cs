using Official.QueryModel.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Official.Interface.Facade.Contracts.IFacadeQuery.Term
{
    public interface ITermFacadeQuery
    {
        Task<List<TermQuery>> Get();
        Task<TermQuery> GetById(int id);
    }
}
