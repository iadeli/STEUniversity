using Official.Domain.Model.Common;
using Z.EntityFramework.Plus;

namespace Official.Domain.Model.CommonEntity.Enum
{
    [AuditDisplay("لیست کمبو")]
    public sealed class Enumuration : Entity
    {
        [AuditDisplay("نام فیلد")]
        public string EnumName { get; private set; }

        [AuditDisplay("عنوان فیلد")]
        public string EnumTitle { get; private set; }

        [AuditDisplay("عنوان لاتین فیلد")]
        public string EnumFiled { get; private set; }

        [AuditDisplay("مقدار فیلد")]
        public string EnumValue { get; private set; }
    }
}
