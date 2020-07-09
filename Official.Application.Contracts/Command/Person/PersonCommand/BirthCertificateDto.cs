using System;
using System.Collections.Generic;
using System.Text;

namespace Official.Application.Contracts.Command.Person
{
    public class BirthCertificateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EFirstName { get; set; }
        public string ELastName { get; set; }
        public string FatherName { get; set; }
        public string No { get; set; }
        public int? IssueCityId { get; set; }
        public int? BirthCountryId { get; set; }
        public int? BirthProvinceId { get; set; }
        public int? BirthCityId { get; set; }
        public string BirthDate { get; set; }
        public int GenderId { get; set; }
        public int PrefixId { get; set; }
        public int? MarriedId { get; set; }

        public long PersonId { get; private set; }
    }
}
