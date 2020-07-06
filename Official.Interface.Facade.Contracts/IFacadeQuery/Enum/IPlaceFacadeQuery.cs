using Official.QueryModel.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Official.Interface.Facade.Contracts.IFacadeQuery.Enum
{
    public interface IPlaceFacadeQuery
    {
        Task<List<PlaceQuery>> GetByType(int typeId, long? placeId);
    }
}
