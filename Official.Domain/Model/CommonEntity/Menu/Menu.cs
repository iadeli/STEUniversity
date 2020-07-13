using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Official.Domain.Model.Common;

namespace Official.Domain.Model.CommonEntity.Menu
{
    [DisplayAttribute(Name ="منو")]
    public sealed class Menu : Entity
    {
        [DisplayAttribute(Name ="نود پدر")]
        public long MenuId { get; set; }

        [DisplayAttribute(Name ="شناسه")]
        public string SystemId { get; private set; }

        [DisplayAttribute(Name ="سطح")]
        public int? Level { get; private set; }

        [DisplayAttribute(Name ="ترتیب")]
        public int? Order { get; private set; }

        [DisplayAttribute(Name ="عنوان")]
        public string Title { get; private set; }

        [DisplayAttribute(Name ="لینک")]
        public string Path { get; set; }

        [DisplayAttribute(Name ="آیکون")]
        public string Icon { get; private set; }

        public List<Menu> SubMenus { get; private set; }
    }
}
