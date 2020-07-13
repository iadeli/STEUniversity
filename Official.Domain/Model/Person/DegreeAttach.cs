using Official.Domain.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;
using Z.EntityFramework.Plus;

namespace Official.Domain.Model.Person
{
    [AuditDisplay("پیوست مدرک سوابق شغلی")]
    public class DegreeAttach : ValueObject<DegreeAttach>
    {
        [AuditDisplay("شناسه")]
        public long Id { get; set; }

        [AuditDisplay("فایل پیوست")]
        public byte[] AttachFile { get; set; }

        [AuditDisplay("پسوند فایل")]
        public string Extention { get; set; }


        [AuditDisplay("مدرک رشته تحصیلی")]
        public long HistoryEducationalId { get; set; }

        public HistoryEducational HistoryEducational { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Id;
            yield return AttachFile;
            yield return Extention;
            yield return HistoryEducationalId;
        }

        //private static DegreeAttach instance = null;
        //public static DegreeAttach Instance
        //{
        //    get
        //    {
        //        if (instance == null)
        //        {
        //            instance = new DegreeAttach();
        //        }
        //        return instance;
        //    }
        //}
    }
}
