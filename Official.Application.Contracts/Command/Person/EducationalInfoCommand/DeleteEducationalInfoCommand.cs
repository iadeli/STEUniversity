using System;
using System.Collections.Generic;
using System.Text;

namespace Official.Application.Contracts.Command.Person
{
    public class DeleteEducationalInfoCommand : EducationalInfoDto
    {
        private static DeleteEducationalInfoCommand instance = null;
        public static DeleteEducationalInfoCommand Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DeleteEducationalInfoCommand();
                }
                return instance;
            }
        }
    }
}
