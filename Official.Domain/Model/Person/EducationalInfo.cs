using Official.Domain.Model.Common;
using Official.Domain.Model.CommonEntity.Term;
using System.ComponentModel.DataAnnotations;

namespace Official.Domain.Model.Person
{
    [DisplayAttribute(Name ="اطلاعات شغلی")]
    public sealed class EducationalInfo : Entity
    {
        [DisplayAttribute(Name ="سقف واحد")]
        public int MaxUnit { get; private set; }

        [DisplayAttribute(Name ="فعال")]
        public bool? Status { get; private set; }

        [DisplayAttribute(Name ="نوع مدرس")]
        public int TeacherTypeId { get; private set; }

        [DisplayAttribute(Name ="مدرس معارف")]
        public bool? ReligiousTeacher { get; private set; }

        [DisplayAttribute(Name ="مدرس دفاع مقدس")]
        public bool? HolyDefenseTeacher { get; private set; }

        [DisplayAttribute(Name ="ترم آموزشی")]
        public long TermId { get; private set; }

        [DisplayAttribute(Name ="نام فرد")]
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
