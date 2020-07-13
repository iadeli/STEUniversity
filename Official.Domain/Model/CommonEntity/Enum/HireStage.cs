using Official.Domain.Model.Common;
using System.ComponentModel.DataAnnotations;

namespace Official.Domain.Model.CommonEntity.HireStage
{
    [DisplayAttribute(Name ="حالت استخدامی")]
    public class HireStage : Entity
    {
        [DisplayAttribute(Name ="عنوان")]
        public string Name { get; set; }

        //private HireStage()
        //{
        //}
        //private static HireStage instance = null;
        //public static HireStage Instance
        //{
        //    get
        //    {
        //        if (instance == null)
        //        {
        //            instance = new HireStage();
        //        }
        //        return instance;
        //    }
        //}
    }
}
