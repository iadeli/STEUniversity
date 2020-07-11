using Official.Domain.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Official.Domain.Model.Person
{
    public class BirthCertificate : ValueObject<BirthCertificate>
    {
        //public long Id { get; private set; }
        public string EFirstName { get; private set; }
        public string ELastName { get; private set; }
        public string FatherName { get; private set; }
        public string No { get; private set; }
        public int? IssueCityId { get; private set; }
        public int? BirthCountryId { get; private set; }
        public int? BirthProvinceId { get; private set; }
        public int? BirthCityId { get; private set; }
        public string BirthDate { get; private set; }
        public int? GenderId { get; private set; }
        public int? PrefixId { get; private set; }
        public int? MarriedId { get; private set; }

        public long PersonId { get; set; }

        public Person Person { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return EFirstName;
            yield return ELastName;
            yield return FatherName;
            yield return No;
            yield return IssueCityId;
            yield return BirthCountryId;
            yield return BirthCityId;
            yield return GenderId;
            yield return PrefixId;
            yield return MarriedId;
            yield return PersonId;
        }
    }
}
