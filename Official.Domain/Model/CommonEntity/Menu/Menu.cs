using System.Collections.Generic;
using Official.Domain.Model.Common;
using Z.EntityFramework.Plus;

namespace Official.Domain.Model.CommonEntity.Menu
{
    [AuditDisplay("منو")]
    public sealed class Menu : Entity
    {
        [AuditDisplay("نود پدر")]
        public long MenuId { get; set; }

        [AuditDisplay("شناسه")]
        public string SystemId { get; private set; }

        [AuditDisplay("سطح")]
        public int? Level { get; private set; }

        [AuditDisplay("ترتیب")]
        public int? Order { get; private set; }

        [AuditDisplay("عنوان")]
        public string Title { get; private set; }

        [AuditDisplay("لینک")]
        public string Path { get; set; }

        [AuditDisplay("آیکون")]
        public string Icon { get; private set; }

        public List<Menu> SubMenus { get; private set; }
    }
}
