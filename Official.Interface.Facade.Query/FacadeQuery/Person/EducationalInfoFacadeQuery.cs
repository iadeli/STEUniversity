using Official.Interface.Facade.Contracts.IFacadeQuery.Person;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;
using Official.QueryModel.Model;
using System.Threading.Tasks;
using System.Linq;

namespace Official.Interface.Facade.Query.FacadeQuery.Person
{
    public class EducationalInfoFacadeQuery : IEducationalInfoFacadeQuery
    {
        private readonly IDbConnection _connection;
        public EducationalInfoFacadeQuery(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<List<EducationalInfoQuery>> Get()
        {
            try
            {
                var sql = "select * from EducationalInfos";
                var data = await _connection.QueryAsync<EducationalInfoQuery>(sql);
                return data.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public async Task<EducationalInfoQuery> GetById(int id)
        {
            try
            {
                var sql = "select * from EducationalInfos where Id = @Id";
                var data = await _connection.QueryFirstOrDefaultAsync<EducationalInfoQuery>(sql, new { Id = id });
                return data;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
