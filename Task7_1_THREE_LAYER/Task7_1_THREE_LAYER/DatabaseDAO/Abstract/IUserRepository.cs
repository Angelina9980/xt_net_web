using Epam.Nodes.Entities;
using System.Collections.Generic;


namespace DatabaseDAO.Abstract
{
    public interface IUserRepository
    {
        void AddUser(UserEntity user);
        void DeleteUserById(int id);
        List<UserEntity> GetAllUsers();
        UserEntity GetUserById(int id);
        void EditUser(UserEntity user);
    }
}
