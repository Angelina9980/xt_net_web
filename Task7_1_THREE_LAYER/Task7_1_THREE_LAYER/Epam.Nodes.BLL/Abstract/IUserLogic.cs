using Domain;
using Epam.Nodes.Entities;
using System;
using System.Collections.Generic;

namespace Epam.Nodes.BLL.Abstract
{
    public interface IUserLogic
    {
        void AddUser(User user);
        void DeleteUserById(int id);
        List<UserEntity> GetAllUsers();
    }
}
