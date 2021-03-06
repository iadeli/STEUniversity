﻿namespace Official.Application.Contracts.Command.Person.PersonCommand
{
    public class BirthCertificateDto
    {
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
