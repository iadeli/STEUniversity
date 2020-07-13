using Official.Domain.Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Official.Domain.Model.Person
{
    [DisplayAttribute(Name ="اطلاعات سایر فرد")]
    public class PersonDetail : ValueObject<PersonDetail>
    {
        public long Id { get; private set; }

        [DisplayAttribute(Name ="شماره نظام وظیفه")]
        public int? EnlistId { get; private set; }

        [DisplayAttribute(Name ="کد نظام وظیفه")]
        public string EnlistCode { get; private set; }

        [DisplayAttribute(Name ="دین")]
        public int? ReligionId { get; private set; }

        [DisplayAttribute(Name ="مذهب")]
        public int? SubReligionId { get; private set; }

        [DisplayAttribute(Name ="ملیت")]
        public int? NationalityId { get; private set; }

        [DisplayAttribute(Name ="فومیت")]
        public int? EthnicityId { get; private set; }

        [DisplayAttribute(Name ="بومی")]
        public int? IndigenousSituationId { get; private set; }

        [DisplayAttribute(Name ="نام فرد")]
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
