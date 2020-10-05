using Epam.Nodes.BLL.Abstract;
using Models;
using Mappers;
using System.Collections.Generic;
using System;
using Epam.Nodes.Entities;

namespace Controllers
{
    public class UserController
    {
        private readonly IUserLogic _userLogic;

        public UserController(IUserLogic userLogic)
        {
            _userLogic = userLogic;
        }

        public void AddUser(UserModel user)
        {
            _userLogic.AddUser(user.ToDomain());
        }

        public void DeleteUserById(int id)
        {
            _userLogic.DeleteUserById(id);
        }

        public List<UserEntity> GetAllUsers()
        {
            return _userLogic.GetAllUsers();
        }
        public void EditUser(UserModel model)
        {
            _userLogic.EditUser(model.ToDomain());
        }

        public UserEntity GetUserById(int id)
        {
            return _userLogic.GetUserById(id);
        }
    }
}
