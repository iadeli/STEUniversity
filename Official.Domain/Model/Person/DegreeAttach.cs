using Official.Domain.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Official.Domain.Model.Person
{
    public class DegreeAttach : ValueObject<DegreeAttach>
    {
        public long Id { get; set; }
        public byte AttachFile { get; set; }
        public string Extention { get; set; }

        public long HistoryEducationalId { get; set; }

        public HistoryEducational HistoryEducational { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
            yield return AttachFile;
            yield return Extention;
            yield return HistoryEducationalId;
        }
    }
}
