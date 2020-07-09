using System;
using System.Collections.Generic;
using System.Text;

namespace Official.Application.Contracts.Command.Person
{
    public class HistoryEducationalDto
    {
        public long UniversityId { get; set; }
        public long DegreeId { get; set; }
        public long AverageScore { get; set; }
        public string EndDate { get; set; }
        public string DegreeDate { get; set; }
        public int? DegreeStatus { get; set; }

        public long PersonId { get; private set; }
    }
}
