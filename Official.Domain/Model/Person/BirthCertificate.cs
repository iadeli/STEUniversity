using Official.Domain.Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Official.Domain.Model.Person
{
    [DisplayAttribute(Name ="اطلاعات شناسنامه")]
    public class BirthCertificate : ValueObject<BirthCertificate>
    {
        //public long Id { get; private set; }
        [DisplayAttribute(Name ="نام لاتین")]
        public string EFirstName { get; private set; }

        [DisplayAttribute(Name ="نام خانوادگی لاتین")]
        public string ELastName { get; private set; }

        [DisplayAttribute(Name ="نام پدر")]
        public string FatherName { get; private set; }

        [DisplayAttribute(Name ="شماره شناسنامه")]
        public string No { get; private set; }

        [DisplayAttribute(Name ="شهر محل صدور")]
        public int? IssueCityId { get; private set; }

        [DisplayAttribute(Name ="کشور محل تولد")]
        public int? BirthCountryId { get; private set; }

        [DisplayAttribute(Name ="استان محل تولد")]
        public int? BirthProvinceId { get; private set; }

        [DisplayAttribute(Name ="شهر محل تولد")]
        public int? BirthCityId { get; private set; }

        [DisplayAttribute(Name ="تاریخ تولد")]
        public string BirthDate { get; private set; }

        [DisplayAttribute(Name ="اطلاعات شناسنامه")]
        public int? GenderId { get; private set; }

        [DisplayAttribute(Name ="اطلاعات شناسنامه")]
        public int? PrefixId { get; private set; }

        [DisplayAttribute(Name ="وضعیت تاهل")]
        public int? MarriedId { get; private set; }

        [DisplayAttribute(Name ="نام فرد")]
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
