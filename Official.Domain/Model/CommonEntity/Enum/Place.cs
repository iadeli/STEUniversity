using Official.Domain.Model.Common;
using System.ComponentModel.DataAnnotations;

namespace Official.Domain.Model.CommonEntity.Enum
{
    [DisplayAttribute(Name ="لیست کشور، استان و شهر")]
    public sealed class Place : Entity
    {
        [DisplayAttribute(Name ="نود پدر محل")]
        public long PlaceId { get; set; }

        [DisplayAttribute(Name ="نوع محل")]
        public int Type { get; private set; }

        [DisplayAttribute(Name ="نام محل")]
        public string Name { get; private set; }
    }
}
