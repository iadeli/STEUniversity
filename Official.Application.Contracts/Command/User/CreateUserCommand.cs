﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Official.Application.Contracts.Command.User
{
    public class CreateUserCommand : LoginDto
    {
        public long PersonId { get; set; }
        public bool Succeeded { get; set; }
    }
}
