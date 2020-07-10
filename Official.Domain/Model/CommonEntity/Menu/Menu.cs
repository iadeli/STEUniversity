using System.Collections.Generic;
using Official.Domain.Model.Common;

namespace Official.Domain.Model.CommonEntity.Menu
{
    public sealed class Menu : Entity
    {
        public string SystemId { get; private set; }
        public int? Level { get; private set; }
        public int? Order { get; private set; }
        public string Title { get; private set; }
        public string Path { get; set; }
        public string Icon { get; private set; }

        public List<Menu> SubMenus { get; private set; }
    }
}
