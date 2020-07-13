using Official.Domain.Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Z.EntityFramework.Plus;

namespace Official.Domain.Model.Person
{
    [AuditDisplay("اطلاعات دفترچه تماس فرد")]
    public class Contact : ValueObject<Contact>
    {
        //public long Id { get; private set; }

        [AuditDisplay("آدرس")]
        public string Address { get; private set; }

        [AuditDisplay("کد پستی")]
        public string PostalCode { get; private set; }

        [AuditDisplay("صندوق پستی")]
        public string PostBox { get; private set; }

        [AuditDisplay("شماره موبایل")]
        public string Mobile { get; private set; }

        [AuditDisplay("شماره محل کار")]
        public string WorkplacePhoneNumber { get; private set; }

        [AuditDisplay("ایمیل")]
        public string Email { get; private set; }

        [AuditDisplay("آدرس محل کار")]
        public string WorkAddress { get; private set; }

        [AuditDisplay("شماره تماس ضروری")]
        public string NecessaryContactNumber { get; private set; }

        [AuditDisplay("توضیحات")]
        public string Description { get; private set; }

        [AuditDisplay("نام فرد")]
        public long PersonId { get; set; }

        public Person Person { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Address;
            yield return PostalCode;
            yield return PostBox;
            yield return Mobile;
            yield return WorkplacePhoneNumber;
            yield return Email;
            yield return WorkAddress;
            yield return NecessaryContactNumber;
            yield return Description;
        }
    }
}
