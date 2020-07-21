using Mapster;

namespace Official.Application.Contracts.Command.Person.HireStageCommand
{
    public class HireStageDto
    {
        [AdaptIgnore]
        public long Id { get; private set; }
        public string Name { get; set; }
        public long TermId { get; set; }
        public string Description { get; set; }
        public bool IsFacultymember { get; set; }
        [AdaptIgnore]
        public long PersonId { get; private set; }
    }
}
