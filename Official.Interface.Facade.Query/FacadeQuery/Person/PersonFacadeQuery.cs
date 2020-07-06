using Official.QueryModel.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Threading.Tasks;
using System.Data;
using System.Linq;
using Official.Interface.Facade.Contracts.IFacadeQuery.Person;

namespace Official.Interface.Facade.Query.FacadeQuery.Person
{
    public class PersonFacadeQuery : IPersonFacadeQuery
    {
        private readonly IDbConnection _connection;
        public PersonFacadeQuery(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<List<PersonQuery>> Get()
        {
            try
            {
                var sql = "SELECT * FROM Persons";
                var data = await _connection.QueryAsync<PersonQuery>(sql);
                return data.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<PersonQuery> GetById(int id)
        {
            try
            {
                var sql = "SELECT * FROM Persons WHERE ID = @Id";
                var data = await _connection.QueryFirstOrDefaultAsync<PersonQuery>(sql, new { Id = id });
                return data;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
