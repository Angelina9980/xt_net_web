using Epam.Nodes.DAL.Abstract;
using Epam.Nodes.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Epam.Nodes.DAL
{
    public class UserRepository : IUserRepository
    {
        private readonly string directoryPath = @"C:\UsersStorage";
        private readonly string fileType = ".json";
        int userId = 1;

        public void AddUser(UserEntity user)
        {
            if (user == null)
            {
                throw new ArgumentNullException();
            }
            DirectoryInfo directory = new DirectoryInfo(directoryPath);

            if (!directory.Exists)
            {
                directory.Create();
            }
            
            if (userId == 0)
            {
                userId = 1;
            }

            user.Id = userId;
            userId++;
            string userFileName = directoryPath + "\\" + user.Id + fileType;
            using (StreamWriter writer = new StreamWriter(userFileName, true))
            {
                writer.Write(JsonConvert.SerializeObject(user));
            }
        }

        public void DeleteUserById(int id)
        {
            string userFileName = directoryPath + "\\" + id + fileType;
            if (File.Exists(userFileName))
            {
                File.Delete(userFileName);
            }
        }

        public void EditUser(UserEntity user)
        {
            var currentUser = GetUserById(user.Id);
            if (currentUser.Name != user.Name || currentUser.ListOfAwards != user.ListOfAwards || currentUser.DateOfBirth != user.DateOfBirth)
            {
                DeleteUserById(currentUser.Id);
                userId--;
                AddUser(new UserEntity {Name = user.Name, ListOfAwards = user.ListOfAwards, DateOfBirth = user.DateOfBirth, Id = user.Id, Age = user.Age});
            }
        }

        public List<UserEntity> GetAllUsers()
        {
            List<UserEntity> userEntities = new List<UserEntity>();
            DirectoryInfo directory = new DirectoryInfo(directoryPath);
            if (directory.Exists)
            {
                foreach (var userFile in directory.GetFiles())
                {
                    using (StreamReader reader = new StreamReader(userFile.FullName))
                    {
                       userEntities.Add(JsonConvert.DeserializeObject<UserEntity>(reader.ReadToEnd()));
                    }
                }
            }
            return userEntities;
        }

        public UserEntity GetUserById(int id)
        {
            var user = GetAllUsers().FirstOrDefault(elem => elem.Id == id);
            if (user != default(UserEntity))
            {
                return user;
            }
            else
            {
                return null;
            }
        }
    }
}
