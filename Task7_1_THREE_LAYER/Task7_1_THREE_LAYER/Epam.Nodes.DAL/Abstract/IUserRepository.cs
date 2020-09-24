using Epam.Nodes.Entities;
using System;
using System.Collections.Generic;

namespace Epam.Nodes.DAL.Abstract
{
    public interface IUserRepository
    {
        void AddUser(UserEntity user);
        void DeleteUserById(int id);
        List<UserEntity> GetAllUsers();
    }
}
