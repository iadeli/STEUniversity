﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Official.Application.Contracts.Command.Person
{
    public class DeletePersonCommand : PersonDto
    {
        private DeletePersonCommand()
        {
        }
        private static DeletePersonCommand instance = null;
        public static DeletePersonCommand Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DeletePersonCommand();
                }
                return instance;
            }
        }
    }
}