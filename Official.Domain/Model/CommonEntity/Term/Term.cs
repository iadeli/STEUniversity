using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Official.Domain.Model.Common;
using Official.Domain.Model.Person;

namespace Official.Domain.Model.CommonEntity.Term
{
    [DisplayAttribute(Name ="ترم آموزشی")]
    public sealed class Term : Entity
    {
        [DisplayAttribute(Name ="شماره")]
        public int No { get; set; }

        [DisplayAttribute(Name ="از سال")]
        public string FromYear { get; set; }

        [DisplayAttribute(Name ="تا سال")]
        public string ToYear { get; set; }

        [DisplayAttribute(Name ="عنوان")]
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
