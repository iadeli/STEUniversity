using Mapster;

namespace Official.Application.Contracts.Command.Person.HistoryEducationalCommand
{
    public class HistoryEducationalDto
    {
        [AdaptIgnore]
        public long Id { get; private set; }
        public long UniversityId { get; set; }
        public long DegreeId { get; set; }
        public long GradeId { get; set; }
        public long MajorSubjectId { get; set; }
        public long AverageScore { get; set; }
        public string EndDate { get; set; }
        public string DegreeDate { get; set; }
        public int? DegreeStatus { get; set; }

        [AdaptIgnore]
        public long PersonId { get; private set; }

        public byte[] AttachFile { get; set; }
        public string Extention { get; set; }
    }
}
