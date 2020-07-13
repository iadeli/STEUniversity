using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Official.Domain.Model.Common;

namespace Official.Domain.Model.Person
{
    [DisplayAttribute(Name ="اطلاعات سوابق شغلی")]
    public class HistoryEducational : Entity
    {
        [DisplayAttribute(Name ="نام دانشگاه")]
        public long UniversityId { get; set; }

        [DisplayAttribute(Name ="عنوان مدرک")]
        public long DegreeId { get; set; }

        [DisplayAttribute(Name ="مقطع تحصیلی")]
        public long GradeId { get; set; }

        [DisplayAttribute(Name ="رشته تحصیلی")]
        public long MajorSubjectId { get; set; }

        [DisplayAttribute(Name ="معدل")]
        public long AverageScore { get; set; }

        [DisplayAttribute(Name ="تاریخ اتمام")]
        public string EndDate { get; set; }

        [DisplayAttribute(Name ="تاریخ مدرک")]
        public string DegreeDate { get; set; }

        [DisplayAttribute(Name ="وضعیت مدرک")]
        public int? DegreeStatus { get; set; }

        [DisplayAttribute(Name ="نام فرد")]
        public long PersonId { get; set; }

        public Person Person { get; set; }
        public List<DegreeAttach> DegreeAttaches { get; set; }

        public HistoryEducational()
        {
            DegreeAttaches = new List<DegreeAttach>();
        }

        //private static HistoryEducational instance = null;
        //public static HistoryEducational Instance
        //{
        //    get
        //    {
        //        if (instance == null)
        //        {
        //            instance = new HistoryEducational();
        //        }
        //        instance.DegreeAttaches.Clear();
        //        return instance;
        //    }
        //}
    }
}
