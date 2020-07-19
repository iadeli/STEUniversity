namespace Official.Application.Contracts.Command.Person.HireStageCommand
{
    public class CreateHireStageCommand : HireStageDto
    {
        public new long PersonId { get; set; }
    }
}
