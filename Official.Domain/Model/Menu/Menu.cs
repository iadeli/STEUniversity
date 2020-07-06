using Official.Domain.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Official.Domain.Model.Menu
{
    public sealed class Menu : AggregateRoot
    {
        public string SystemId { get; private set; }
        public int? Level { get; private set; }
        public int? Order { get; private set; }
        public string Title { get; private set; }
        public string Icon { get; private set; }

        public List<Menu> SubMenus { get; private set; }
    }
}
