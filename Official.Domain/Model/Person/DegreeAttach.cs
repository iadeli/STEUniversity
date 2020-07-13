using Official.Domain.Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Official.Domain.Model.Person
{
    [DisplayAttribute(Name ="پیوست مدرک سوابق شغلی")]
    public class DegreeAttach : ValueObject<DegreeAttach>
    {
        [DisplayAttribute(Name ="شناسه")]
        public long Id { get; set; }

        [DisplayAttribute(Name ="فایل پیوست")]
        public byte[] AttachFile { get; set; }

        [DisplayAttribute(Name ="پسوند فایل")]
        public string Extention { get; set; }


        [DisplayAttribute(Name ="مدرک رشته تحصیلی")]
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
