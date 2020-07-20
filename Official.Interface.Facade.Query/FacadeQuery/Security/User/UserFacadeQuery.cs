using Official.Interface.Facade.Contracts.IFacadeQuery.Security.User;
using Official.QueryModel.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Linq;

namespace Official.Interface.Facade.Query.FacadeQuery.Security.User
{
    public class UserFacadeQuery : IUserFacadeQuery
    {
        private readonly IDbConnection _connection;
        public UserFacadeQuery(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<List<UserQuery>> GetUsers()
        {
            try
            {
                var sql = @"
                    select anu.Id AS UserId, p.Id AS PersonId, (p.FirstName + ' ' + p.LastName) AS FullName, anu.UserName, p.NationalCode, c.Mobile, c.Email
                    from AspNetUsers anu 
                    INNER JOIN Persons p ON anu.PersonId = p.Id 
                    INNER JOIN Contacts c ON p.Id = c.PersonId
                    ";
                var users = await _connection.QueryAsync<UserQuery>(sql);
                return users.ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
