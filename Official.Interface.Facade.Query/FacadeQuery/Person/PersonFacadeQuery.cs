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
                var sql = @"select p.[Id] ,[NationalCode] ,[PersonnelCode] ,[TeacherCode] ,[FirstName] ,[LastName], [EnlistId], [EnlistCode], [ReligionId], [SubReligionId]
                                ,[NationalityId], [EthnicityId], [IndigenousSituationId], [EFirstName] ,[ELastName] ,[FatherName] ,[No] ,[IssueCityId] ,[BirthCountryId]
		                        ,[BirthProvinceId] ,[BirthCityId] ,[BirthDate] ,[GenderId] ,[PrefixId] ,[MarriedId] ,[Address] ,[PostalCode] ,[PostBox] ,[Mobile] ,[WorkplacePhoneNumber]
		                        ,[Email] ,[WorkAddress] ,[NecessaryContactNumber] ,[Description]  
                            from Persons p inner join BirthCertificates bc on p.Id = bc.PersonId inner join PersonDetails pd on p.Id = pd.PersonId inner join Contacts c on p.Id = c.PersonId";
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
                var sql = @"select p.[Id] ,[NationalCode] ,[PersonnelCode] ,[TeacherCode] ,[FirstName] ,[LastName], [EnlistId], [EnlistCode], [ReligionId], [SubReligionId]
                                ,[NationalityId], [EthnicityId], [IndigenousSituationId], [EFirstName] ,[ELastName] ,[FatherName] ,[No] ,[IssueCityId] ,[BirthCountryId]
		                        ,[BirthProvinceId] ,[BirthCityId] ,[BirthDate] ,[GenderId] ,[PrefixId] ,[MarriedId] ,[Address] ,[PostalCode] ,[PostBox] ,[Mobile] ,[WorkplacePhoneNumber]
		                        ,[Email] ,[WorkAddress] ,[NecessaryContactNumber] ,[Description] 
                            from Persons p inner join BirthCertificates bc on p.Id = bc.PersonId inner join PersonDetails pd on p.Id = pd.PersonId inner join Contacts c on p.Id = c.PersonId WHERE p.ID = @Id";
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
