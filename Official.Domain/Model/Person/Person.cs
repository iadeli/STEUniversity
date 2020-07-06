using System;
using System.Collections.Generic;
using System.Text;
using Official.Domain.Model.Common;

namespace Official.Domain.Model.Person
{
    public sealed class Person : AggregateRoot
    {
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

        private Person()
        {
        }
        private static Person instance = null;
        public static Person Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Person();
                }
                return instance;
            }
        }
    }
}
