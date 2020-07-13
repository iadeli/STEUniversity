using Official.Domain.Model.Common;
using Official.Domain.Model.CommonEntity.Term;
using Z.EntityFramework.Plus;

namespace Official.Domain.Model.Person
{
    public sealed class EducationalInfo : Entity
    {
        [AuditDisplay("سقف واحد")]
        public int MaxUnit { get; private set; }
        public bool? Status { get; private set; }
        public int TeacherTypeId { get; private set; }
        public bool? ReligiousTeacher { get; set; }
        public bool? HolyDefenseTeacher { get; set; }

        public long TermId { get; private set; }
        public long PersonId { get; private set; }

        public Person Person { get; private set; }
        public Term Term { get; private set; }

        //private EducationalInfo()
        //{
        //}
        //private static EducationalInfo instance = null;
        //public static EducationalInfo Instance
        //{
        //    get
        //    {
        //        if (instance == null)
        //        {
        //            instance = new EducationalInfo();
        //        }
        //        return instance;
        //    }
        //}
    }
}
