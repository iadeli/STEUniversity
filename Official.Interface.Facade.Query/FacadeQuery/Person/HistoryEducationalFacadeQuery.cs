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
                var sql = "select he.*, da.AttachFile, da.Extention, da.HistoryEducationalId from HistoryEducationals he left join DegreeAttaches da on he.Id = da.HistoryEducationalId ";
                var data = await _connection.QueryAsync<HistoryEducationalQuery>(sql);
                return data.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<HistoryEducationalQuery> GetByIdAsync(long id)
        {
            try
            {
                var sql = "select he.*, da.AttachFile, da.Extention, da.HistoryEducationalId from HistoryEducationals he left join DegreeAttaches da on he.Id = da.HistoryEducationalId where he.Id = @Id";
                var data = await _connection.QueryFirstOrDefaultAsync<HistoryEducationalQuery>(sql, new { Id = id });
                return data;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<HistoryEducationalQuery>> GetByPersonIdAsync(long personId)
        {
            try
            {
                var sql = "select he.*, da.AttachFile, da.Extention, da.HistoryEducationalId from HistoryEducationals he left join DegreeAttaches da on he.Id = da.HistoryEducationalId where he.PersonId = @PersonId";
                var data = await _connection.QueryAsync<HistoryEducationalQuery>(sql, new { PersonId = personId });
                return data.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
