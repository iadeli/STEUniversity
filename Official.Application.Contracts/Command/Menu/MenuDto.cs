using System;
using System.Collections.Generic;
using System.Text;

namespace Official.Application.Contracts.Command.Menu
{
    public class MenuDto
    {
        public long Id { get; set; }
        public long MenuId { get; set; }
        public string SystemId { get; set; }
        public int? Level { get; set; }
        public int? Order { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
    }
}
