﻿using Core.Database;
using Core.Models.BusinessModels;
using Core.Models.FilterModels;
using Core.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.OperationInterfaces
{
    public interface IUserOperations
    {
        IEnumerable<UserViewModel> GetUsers(UserFilterModel filter);
        UserModel GetUser(int id);
        UserViewModel RegisterUser(UserModel user);
        void UpdateUser(UserModel user);
        void DeleteUser(int id);
    }
}
