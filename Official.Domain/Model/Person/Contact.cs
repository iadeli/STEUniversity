using Official.Domain.Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Official.Domain.Model.Person
{
    [DisplayAttribute(Name ="اطلاعات دفترچه تماس فرد")]
    public class Contact : ValueObject<Contact>
    {
        //public long Id { get; private set; }

        [DisplayAttribute(Name ="آدرس")]
        public string Address { get; private set; }

        [DisplayAttribute(Name ="کد پستی")]
        public string PostalCode { get; private set; }

        [DisplayAttribute(Name ="صندوق پستی")]
        public string PostBox { get; private set; }

        [DisplayAttribute(Name ="شماره موبایل")]
        public string Mobile { get; private set; }

        [DisplayAttribute(Name ="شماره محل کار")]
        public string WorkplacePhoneNumber { get; private set; }

        [DisplayAttribute(Name ="ایمیل")]
        public string Email { get; private set; }

        [DisplayAttribute(Name ="آدرس محل کار")]
        public string WorkAddress { get; private set; }

        [DisplayAttribute(Name ="شماره تماس ضروری")]
        public string NecessaryContactNumber { get; private set; }

        [DisplayAttribute(Name ="توضیحات")]
        public string Description { get; private set; }

        [DisplayAttribute(Name ="نام فرد")]
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
