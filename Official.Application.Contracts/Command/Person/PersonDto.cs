using System;
using System.Collections.Generic;
using System.Text;

namespace Official.Application.Contracts.Command.Person
{
    public class PersonDto
    {
        public long Id { get; set; }
        public string Address { get; private set; }
        public string BirthCertificateNumber { get; private set; }
        public int? BirthCountryId { get; private set; }
        public string BirthDate { get; private set; }
        public string Description { get; private set; }
        public string EnlistCode { get; private set; }
        public int? BirthCityId { get; private set; }
        public string Email { get; private set; }
        public int? EthnicityId { get; private set; }
        public string FatherName { get; private set; }
        public int? SubReligionId { get; private set; }
        public int GenderId { get; private set; }
        public int? IndigenousSituationId { get; private set; }
        public string EFirstName { get; private set; }
        public string ELastName { get; private set; }
        public string LastName { get; private set; }
        public int? MarriedId { get; private set; }
        public int? EnlistId { get; private set; }
        public string Mobile { get; private set; }
        public string FirstName { get; private set; }
        public string NationalCode { get; private set; }
        public int? NationalityId { get; private set; }
        public string NecessaryContactNumber { get; private set; }
        public int? IssueCityId { get; private set; }
        public string PostBox { get; private set; }
        public string PostalCode { get; private set; }
        public int PrefixId { get; private set; }
        public int? BirthProvinceId { get; private set; }
        public int? ReligionId { get; private set; }
        public string WorkAddress { get; private set; }
        public string WorkplacePhoneNumber { get; private set; }
    }
}
