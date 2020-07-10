using System;
using System.Collections.Generic;
using System.Text;
using Official.Domain.Model.Common;

namespace Official.Domain.Model.Person
{
    public class HistoryEducational : Entity
    {
        public long UniversityId { get; set; }
        public long DegreeId { get; set; }
        public long AverageScore { get; set; }
        public string EndDate { get; set; }
        public string DegreeDate { get; set; }
        public int? DegreeStatus { get; set; }

        public long PersonId { get; set; }

        public Person Person { get; set; }
        public List<DegreeAttach> DegreeAttaches { get; set; }


        private static HistoryEducational instance = null;
        public static HistoryEducational Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HistoryEducational();
                }
                return instance;
            }
        }
    }
}
