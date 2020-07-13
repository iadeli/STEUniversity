using System.Collections.Generic;
using Official.Domain.Model.Common;
using Official.Domain.Model.Person;
using Z.EntityFramework.Plus;

namespace Official.Domain.Model.CommonEntity.Term
{
    [AuditDisplay("ترم آموزشی")]
    public sealed class Term : Entity
    {
        [AuditDisplay("شماره")]
        public int No { get; set; }

        [AuditDisplay("از سال")]
        public string FromYear { get; set; }

        [AuditDisplay("تا سال")]
        public string ToYear { get; set; }

        [AuditDisplay("عنوان")]
        public string Title { get; set; }

        public List<EducationalInfo> EducationalInfos { get; set; }

        //private Term()
        //{
        //}
        //private static Term instance = null;
        //public static Term Instance
        //{
        //    get
        //    {
        //        if (instance == null)
        //        {
        //            instance = new Term();
        //        }
        //        return instance;
        //    }
        //}
    }
}
