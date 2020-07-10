using Official.Domain.Model.Common;

namespace Official.Domain.Model.CommonEntity.Enum
{
    public sealed class Place : Entity
    {
        public long PlaceId { get; set; }
        public int Type { get; private set; }
        public string Name { get; private set; }
    }
}
