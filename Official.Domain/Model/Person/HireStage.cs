using Official.Domain.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Official.Domain.Model.Person
{
    public class HireStage : Entity
    {
        public string Name { get; set; }

        private HireStage()
        {
        }
        private static HireStage instance = null;
        public static HireStage Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HireStage();
                }
                return instance;
            }
        }
    }
}
