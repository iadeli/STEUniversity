using Official.Domain.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Official.Domain.Model.Person
{
    public class PersonDetail : ValueObject<PersonDetail>
    {
        public long Id { get; set; }
        public int? EnlistId { get; private set; }
        public string EnlistCode { get; private set; }
        public int? ReligionId { get; private set; }
        public int? SubReligionId { get; private set; }
        public int? NationalityId { get; private set; }
        public int? EthnicityId { get; private set; }
        public int? IndigenousSituationId { get; private set; }

        public long PersonId { get; set; }

        public Person Person { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
            yield return EnlistId;
            yield return EnlistCode;
            yield return ReligionId;
            yield return SubReligionId;
            yield return NationalityId;
            yield return EthnicityId;
            yield return IndigenousSituationId;
        }
    }
}
