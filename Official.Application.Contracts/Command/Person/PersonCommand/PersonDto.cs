namespace Official.Application.Contracts.Command.Person.PersonCommand
{
    public class PersonDto
    {
        public long Id { get; set; }
        public string TeacherCode { get; set; }
        public string PersonnelCode { get; set; }
        public string NationalCode { get; set; }

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

        public int? EnlistId { get; set; }
        public string EnlistCode { get; set; }
        public int? ReligionId { get; set; }
        public int? SubReligionId { get; set; }
        public int? NationalityId { get; set; }
        public int? EthnicityId { get; set; }
        public int? IndigenousSituationId { get; set; }

        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string PostBox { get; set; }
        public string Mobile { get; set; }
        public string WorkplacePhoneNumber { get; set; }
        public string Email { get; set; }
        public string WorkAddress { get; set; }
        public string NecessaryContactNumber { get; set; }
        public string Description { get; set; }

        public long PersonId { get; set; }

    }
}
