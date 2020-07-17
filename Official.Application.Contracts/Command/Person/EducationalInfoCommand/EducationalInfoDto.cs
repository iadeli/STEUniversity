namespace Official.Application.Contracts.Command.Person.EducationalInfoCommand
{
    public class EducationalInfoDto
    {
        public long Id { get; set; }
        public int MaxUnit { get; set; }
        public bool Status { get; set; }
        public int TeacherTypeId { get; set; }
        public bool ReligiousTeacher { get; set; }
        public bool HolyDefenseTeacher { get; set; }

        public long TermId { get; set; }
        public long PersonId { get; private set; }
    }
}
