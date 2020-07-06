using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Official.QueryModel.Model;

namespace Official.Interface.Facade.Contracts.IFacadeQuery.Enum
{
    public interface IEnumFacadeQuery
    {
        Task<List<EnumQuery>> GetByName(string Name);
    }
}
