using Official.Domain.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Official.Domain.Model.Person
{
    public class BirthCertificate : Entity
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string EFirstName { get; private set; }
        public string ELastName { get; private set; }
        public string FatherName { get; private set; }
        public string No { get; private set; }
        public int? IssueCityId { get; private set; }
        public int? BirthCountryId { get; private set; }
        public int? BirthProvinceId { get; private set; }
        public int? BirthCityId { get; private set; }
        public string BirthDate { get; private set; }
        public int GenderId { get; private set; }
        public int PrefixId { get; private set; }
        public int? MarriedId { get; private set; }

        public long PersonId { get; set; }

        public Person Person { get; set; }
    }
}
