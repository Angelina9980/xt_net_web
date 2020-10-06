using Domain;
using Epam.Nodes.BLL.Abstract;
//using Epam.Nodes.DAL.Abstract;
using DatabaseDAO.Abstract;
using Epam.Nodes.Entities;
using Mappers;
using System;
using System.Collections.Generic;


namespace Epam.Nodes.BLL
{
    public class UserLogic : IUserLogic
    {

        private readonly IUserRepository _usersRepository;

        public UserLogic(IUserRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public void AddUser(User user)
        {
            _usersRepository.AddUser(user.ToEntity());
        }

        public void DeleteUserById(int id)
        {
            _usersRepository.DeleteUserById(id);
        }

        public void EditUser(User user)
        {
            _usersRepository.EditUser(user.ToEntity());
        }

        public List<UserEntity> GetAllUsers()
        {
            return _usersRepository.GetAllUsers();
        }

        public UserEntity GetUserById(int id)
        {
            return _usersRepository.GetUserById(id);
        }
    }
}
