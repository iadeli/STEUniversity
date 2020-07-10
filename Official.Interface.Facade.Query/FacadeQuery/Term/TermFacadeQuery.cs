using Dapper;
using Official.Interface.Facade.Contracts.IFacadeQuery.Term;
using Official.QueryModel.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Official.Interface.Facade.Query.FacadeQuery.Term
{
    public class TermFacadeQuery : ITermFacadeQuery
    {
        private readonly IDbConnection _connection;
        public TermFacadeQuery(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<List<TermQuery>> Get()
        {
            try
            {
                var sql = "select * from Terms";
                var data = await _connection.QueryAsync<TermQuery>(sql);
                return data.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<TermQuery> GetById(int id)
        {
            try
            {
                var sql = "select * from Terms where Id = @Id";
                var data = await _connection.QueryFirstOrDefaultAsync<TermQuery>(sql, new { Id = id });
                return data;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
