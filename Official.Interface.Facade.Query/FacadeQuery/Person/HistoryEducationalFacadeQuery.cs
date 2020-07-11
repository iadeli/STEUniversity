using Dapper;
using Official.Application.Contracts.Command.Person.HistoryEducationalCommand;
using Official.Interface.Facade.Contracts.IFacadeQuery.Person;
using Official.QueryModel.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Official.Interface.Facade.Query.FacadeQuery.Person
{
    public class HistoryEducationalFacadeQuery : IHistoryEducationalFacadeQuery
    {
        private readonly IDbConnection _connection;
        public HistoryEducationalFacadeQuery(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<List<HistoryEducationalQuery>> GetAsync()
        {
            try
            {
                var sql = "select * from HistoryEducationals he inner join DegreeAttaches da on he.Id = da.HistoryEducationalId ";
                var data = await _connection.QueryAsync<HistoryEducationalQuery>(sql);
                return data.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<HistoryEducationalQuery> GetByIdAsync(int id)
        {
            try
            {
                var sql = "select * from HistoryEducationals he inner join DegreeAttaches da on he.Id = da.HistoryEducationalId where he.Id = @Id";
                var data = await _connection.QueryFirstOrDefaultAsync<HistoryEducationalQuery>(sql, new { Id = id });
                return data;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
