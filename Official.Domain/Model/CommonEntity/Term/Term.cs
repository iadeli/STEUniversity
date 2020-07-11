using System.Collections.Generic;
using Official.Domain.Model.Common;
using Official.Domain.Model.Person;

namespace Official.Domain.Model.CommonEntity.Term
{
    public sealed class Term : Entity
    {
        public int No { get; set; }
        public string FromYear { get; set; }
        public string ToYear { get; set; }
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
