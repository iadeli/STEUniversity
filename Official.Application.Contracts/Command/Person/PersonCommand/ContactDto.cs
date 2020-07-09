using System;
using System.Collections.Generic;
using System.Text;

namespace Official.Application.Contracts.Command.Person
{
    public class ContactDto
    {
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string PostBox { get; set; }
        public string Mobile { get; set; }
        public string WorkplacePhoneNumber { get; set; }
        public string Email { get; set; }
        public string WorkAddress { get; set; }
        public string NecessaryContactNumber { get; set; }
        public string Description { get; set; }

        public long PersonId { get; private set; }
    }
}
