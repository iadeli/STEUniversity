using Official.Domain.Model.Common;
using Official.Domain.Model.CommonEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Official.Domain.Model.Person
{
    public sealed class EducationalInfo : Entity
    {
        public int MaxUnit { get; private set; }
        public bool Status { get; private set; }
        public int TeacherTypeId { get; private set; }
        public bool ReligiousTeacher { get; set; }
        public bool HolyDefenseTeacher { get; set; }

        public long TermId { get; private set; }
        public long PersonId { get; private set; }

        public Person Person { get; private set; }
        public Term Term { get; private set; }
    }
}
