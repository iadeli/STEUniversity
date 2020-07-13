using Official.Domain.Model.Common;
using Z.EntityFramework.Plus;

namespace Official.Domain.Model.CommonEntity.Enum
{
    [AuditDisplay("لیست کشور، استان و شهر")]
    public sealed class Place : Entity
    {
        [AuditDisplay("نود پدر محل")]
        public long PlaceId { get; set; }

        [AuditDisplay("نوع محل")]
        public int Type { get; private set; }

        [AuditDisplay("نام محل")]
        public string Name { get; private set; }
    }
}
