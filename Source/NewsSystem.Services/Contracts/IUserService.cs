﻿using NewsSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsSystem.Services.Contracts
{
    public interface IUserService
    {
        IQueryable<User> GetAllUsers();

        User GetUserById(string id);

        void UpdateUserRole(User userToUpdate);
    }
}
