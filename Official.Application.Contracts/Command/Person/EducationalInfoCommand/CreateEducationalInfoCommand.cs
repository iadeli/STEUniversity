﻿namespace Official.Application.Contracts.Command.Person.EducationalInfoCommand
{
    public class CreateEducationalInfoCommand : EducationalInfoDto
    {
        public new long PersonId { get; set; }
    }
}
