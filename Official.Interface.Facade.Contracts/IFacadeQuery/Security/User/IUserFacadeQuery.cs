﻿using Official.QueryModel.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Official.Interface.Facade.Contracts.IFacadeQuery.Security.User
{
    public interface IUserFacadeQuery
    {
        Task<List<UserQuery>> GetUsers();
        Task<List<UserQuery>> GetUserById(long userId);
        Task<List<UserQuery>> GetUserByPersonId(long personId);
    }
}
