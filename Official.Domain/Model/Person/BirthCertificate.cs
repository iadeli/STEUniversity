using Official.Domain.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;
using Z.EntityFramework.Plus;

namespace Official.Domain.Model.Person
{
    [AuditDisplay("اطلاعات شناسنامه")]
    public class BirthCertificate : ValueObject<BirthCertificate>
    {
        //public long Id { get; private set; }
        [AuditDisplay("نام لاتین")]
        public string EFirstName { get; private set; }

        [AuditDisplay("نام خانوادگی لاتین")]
        public string ELastName { get; private set; }

        [AuditDisplay("نام پدر")]
        public string FatherName { get; private set; }

        [AuditDisplay("شماره شناسنامه")]
        public string No { get; private set; }

        [AuditDisplay("شهر محل صدور")]
        public int? IssueCityId { get; private set; }

        [AuditDisplay("کشور محل تولد")]
        public int? BirthCountryId { get; private set; }

        [AuditDisplay("استان محل تولد")]
        public int? BirthProvinceId { get; private set; }

        [AuditDisplay("شهر محل تولد")]
        public int? BirthCityId { get; private set; }

        [AuditDisplay("تاریخ تولد")]
        public string BirthDate { get; private set; }

        [AuditDisplay("اطلاعات شناسنامه")]
        public int? GenderId { get; private set; }

        [AuditDisplay("اطلاعات شناسنامه")]
        public int? PrefixId { get; private set; }

        [AuditDisplay("وضعیت تاهل")]
        public int? MarriedId { get; private set; }

        [AuditDisplay("نام فرد")]
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
