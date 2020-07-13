using Official.Domain.Model.Common;
using Official.Domain.Model.CommonEntity.Term;
using Z.EntityFramework.Plus;

namespace Official.Domain.Model.Person
{
    [AuditDisplay("اطلاعات شغلی")]
    public sealed class EducationalInfo : Entity
    {
        [AuditDisplay("سقف واحد")]
        public int MaxUnit { get; private set; }

        [AuditDisplay("وضعیت")]
        public bool? Status { get; private set; }

        [AuditDisplay("نوع مدرس")]
        public int TeacherTypeId { get; private set; }

        [AuditDisplay("مدرس معارف")]
        public bool? ReligiousTeacher { get; set; }

        [AuditDisplay("مدرس دفاع مقدس")]
        public bool? HolyDefenseTeacher { get; set; }

        [AuditDisplay("ترم آموزشی")]
        public long TermId { get; private set; }

        [AuditDisplay("نام فرد")]
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
