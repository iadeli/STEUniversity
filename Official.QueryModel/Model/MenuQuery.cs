using Official.Application.Contracts.Command.Menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace Official.QueryModel.Model
{
    public class MenuQuery : MenuDto
    {
        public List<MenuQuery> SubMenus { get; set; }
    }
}
