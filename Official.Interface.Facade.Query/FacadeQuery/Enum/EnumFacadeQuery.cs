using Official.Interface.Facade.Contracts.IFacadeQuery.Enum;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Official.QueryModel.Model;
using System.Linq;

namespace Official.Interface.Facade.Query.FacadeQuery.Enum
{
    public class EnumFacadeQuery : IEnumFacadeQuery
    {
        private readonly IDbConnection _connection;
        public EnumFacadeQuery(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<List<EnumQuery>> GetByName(string Name)
        {
            try
            {
                var sql = "SELECT * FROM Enumurations WHERE EnumName = @Name";
                var data = await _connection.QueryAsync<EnumQuery>(sql, new { Name = Name });
                return data.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
