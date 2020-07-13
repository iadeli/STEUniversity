using Official.Domain.Model.Common;
using Z.EntityFramework.Plus;

namespace Official.Domain.Model.CommonEntity.HireStage
{
    [AuditDisplay("حالت استخدامی")]
    public class HireStage : Entity
    {
        [AuditDisplay("عنوان")]
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
