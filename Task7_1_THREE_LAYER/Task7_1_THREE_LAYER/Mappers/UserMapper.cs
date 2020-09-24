using Epam.Nodes.Entities;
using System;
using Domain;
using Models;
using System.IO;
using System.Linq;

namespace Mappers
{
    public static class UserMapper
    {
        public static UserEntity ToEntity(this User user)
        {
            DateTime dateTimeNow = DateTime.Today;
            int age = dateTimeNow.Year - user.DateOfBirth.Year;
            if (user.DateOfBirth > dateTimeNow.AddYears(-age))
            {
                age--;
            }

            return new UserEntity
            {
                Name = user.Name,
                DateOfBirth = user.DateOfBirth,
                Age = age,
                ListOfAwards = user.ListOfAwards
            };
        }
        public static User ToDomain(this UserModel model)
        {
            string awardDirectoryPath = @"C:\AdwardStorage";
            var awardFiles = new DirectoryInfo(awardDirectoryPath).GetFiles();

            var userAwards = model.ListOfAwards;

            if (model == null)
            {
                return null;
            }
            if (userAwards != null)
            {
                for (int i = 0; i < userAwards.Count; i++)
                {
                    if (!awardFiles.Equals(userAwards[i]))
                    {
                        model.ListOfAwards.Remove(userAwards[i]);
                    }
                }
            }

            return new User
            {
                Name = model.Name,
                DateOfBirth = model.DateOfBirth,
                ListOfAwards = model.ListOfAwards
            };
        }
    }
}
