using Official.Domain.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;
using Z.EntityFramework.Plus;

namespace Official.Domain.Model.Person
{
    [AuditDisplay("اطلاعات سایر فرد")]
    public class PersonDetail : ValueObject<PersonDetail>
    {
        //public long Id { get; private set; }

        [AuditDisplay("شماره نظام وظیفه")]
        public int? EnlistId { get; private set; }

        [AuditDisplay("کد نظام وظیفه")]
        public string EnlistCode { get; private set; }

        [AuditDisplay("دین")]
        public int? ReligionId { get; private set; }

        [AuditDisplay("مذهب")]
        public int? SubReligionId { get; private set; }

        [AuditDisplay("ملیت")]
        public int? NationalityId { get; private set; }

        [AuditDisplay("فومیت")]
        public int? EthnicityId { get; private set; }

        [AuditDisplay("بومی")]
        public int? IndigenousSituationId { get; private set; }

        [AuditDisplay("نام فرد")]
        public long PersonId { get; set; }

        public Person Person { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
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
