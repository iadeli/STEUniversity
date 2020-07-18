using Mapster;

namespace Official.Application.Contracts.Command.Person.EducationalInfoCommand
{
    public class EducationalInfoDto
    {
        [AdaptIgnore]
        public long Id { get; private set; }
        public int MaxUnit { get; set; }
        public bool Status { get; set; }
        public int TeacherTypeId { get; set; }
        public bool ReligiousTeacher { get; set; }
        public bool HolyDefenseTeacher { get; set; }

        public long TermId { get; set; }

        [AdaptIgnore]
        public long PersonId { get; private set; }
    }
}
