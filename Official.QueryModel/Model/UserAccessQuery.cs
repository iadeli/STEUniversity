using System;
using System.Collections.Generic;
using System.Text;

namespace Official.QueryModel.Model
{
    public class UserAccessQuery : SecurityQuery
    {
        public long UserId { get; set; }
    }
}
