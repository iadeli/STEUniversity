using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Official.Interface.Facade.Contracts.IFacadeQuery.Person;
using Official.QueryModel.Model;

namespace Official.Interface.Facade.Query.FacadeQuery.Person
{
    public class HireStageFacadeQuery : IHireStageFacadeQuery
    {
        private readonly IDbConnection _connection;
        public HireStageFacadeQuery(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<List<HireStageQuery>> Get()
        {
            try
            {
                var sql = "select *, (CASE WHEN HireTypeId IN (5,6) THEN cast(1 as bit) else cast(0 as bit) END) AS IsFacultymember from HireStages";
                var data = await _connection.QueryAsync<HireStageQuery>(sql);
                return data.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<HireStageQuery> GetById(int id)
        {
            try
            {
                var sql = "select *, (CASE WHEN HireTypeId IN (5,6) THEN cast(1 as bit) else cast(0 as bit) END) AS IsFacultymember from HireStages where Id = @Id";
                var data = await _connection.QueryFirstOrDefaultAsync<HireStageQuery>(sql, new { Id = id });
                return data;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<HireStageQuery>> GetByPersonId(long personId)
        {
            try
            {
                var sql = "select *, (CASE WHEN HireTypeId IN (5,6) THEN cast(1 as bit) else cast(0 as bit) END) AS IsFacultymember from HireStages where PersonId = @PersonId";
                var data = await _connection.QueryAsync<HireStageQuery>(sql, new { PersonId = personId });
                return data.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
