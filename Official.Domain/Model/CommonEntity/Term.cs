using Official.Domain.Model.Common;
using Official.Domain.Model.Person;
using System;
using System.Collections.Generic;
using System.Text;

namespace Official.Domain.Model.CommonEntity
{
    public sealed class Term : Entity
    {
        public int No { get; set; }
        public string FromYear { get; set; }
        public string ToYear { get; set; }
        public string Title { get; set; }

        public List<EducationalInfo> EducationalInfos { get; set; }
    }
}
