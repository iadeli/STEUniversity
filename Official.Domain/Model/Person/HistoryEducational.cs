using System;
using System.Collections.Generic;
using System.Text;
using Official.Domain.Model.Common;
using Z.EntityFramework.Plus;

namespace Official.Domain.Model.Person
{
    [AuditDisplay("اطلاعات سوابق شغلی")]
    public class HistoryEducational : Entity
    {
        [AuditDisplay("نام دانشگاه")]
        public long UniversityId { get; set; }

        [AuditDisplay("عنوان مدرک")]
        public long DegreeId { get; set; }

        [AuditDisplay("مقطع تحصیلی")]
        public long GradeId { get; set; }

        [AuditDisplay("رشته تحصیلی")]
        public long MajorSubjectId { get; set; }

        [AuditDisplay("معدل")]
        public long AverageScore { get; set; }

        [AuditDisplay("تاریخ اتمام")]
        public string EndDate { get; set; }

        [AuditDisplay("تاریخ مدرک")]
        public string DegreeDate { get; set; }

        [AuditDisplay("وضعیت مدرک")]
        public int? DegreeStatus { get; set; }

        [AuditDisplay("نام فرد")]
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
