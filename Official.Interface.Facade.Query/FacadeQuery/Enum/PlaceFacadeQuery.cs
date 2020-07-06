using Official.Interface.Facade.Contracts.IFacadeQuery.Enum;
using Official.QueryModel.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Linq;

namespace Official.Interface.Facade.Query.FacadeQuery.Enum
{
    public class PlaceFacadeQuery : IPlaceFacadeQuery
    {
        private readonly IDbConnection _connection;
        public PlaceFacadeQuery(IDbConnection connection)
        {
            _connection = connection;

        }
        public async Task<List<PlaceQuery>> GetByType(int typeId, long? placeId)
        {
            try
            {
                var sql = "SELECT * FROM Places WHERE Type = @Type AND PlaceId = ISNULL(@PlaceId, PlaceId)";
                var data = await _connection.QueryAsync<PlaceQuery>(sql, new { Type = typeId, PlaceId = placeId });
                return data.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
