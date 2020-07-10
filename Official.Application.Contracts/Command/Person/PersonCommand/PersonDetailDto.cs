namespace Official.Application.Contracts.Command.Person.PersonCommand
{
    public class PersonDetailDto
    {
        public int? EnlistId { get; set; }
        public string EnlistCode { get; set; }
        public int? ReligionId { get; set; }
        public int? SubReligionId { get; set; }
        public int? NationalityId { get; set; }
        public int? EthnicityId { get; set; }
        public int? IndigenousSituationId { get; set; }

        public long PersonId { get; private set; }
    }
}
