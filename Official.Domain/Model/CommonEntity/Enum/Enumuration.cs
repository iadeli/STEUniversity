using Official.Domain.Model.Common;

namespace Official.Domain.Model.CommonEntity.Enum
{
    public sealed class Enumuration : Entity
    {
        public string EnumName { get; private set; }
        public string EnumTitle { get; private set; }
        public string EnumFiled { get; private set; }
        public string EnumValue { get; private set; }
    }
}
