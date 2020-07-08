using Official.Domain.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Official.Domain.Model.Person
{
    public class Contact : ValueObject<Contact>
    {
        public long Id { get; set; }
        public string Address { get; private set; }
        public string PostalCode { get; private set; }
        public string PostBox { get; private set; }
        public string Mobile { get; private set; }
        public string WorkplacePhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string WorkAddress { get; private set; }
        public string NecessaryContactNumber { get; private set; }
        public string Description { get; private set; }

        public long PersonId { get; set; }

        public Person Person { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
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
