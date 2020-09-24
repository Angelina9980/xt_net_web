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
        int userId = 0;

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

            userId++;
            user.Id = userId;
            string userFileName = directoryPath + "\\" + userId + fileType;
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
                userId--;
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
    }
}
