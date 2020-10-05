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
                DateOfBirth = user.DateOfBirth.Date,
                Age = age,
                ListOfAwards = user.ListOfAwards,
                Id = user.Id
            };
        }
        public static User ToDomain(this UserModel model)
        {
            string awardDirectoryPath = @"C:\AwardStorage";
            DirectoryInfo directory = new DirectoryInfo(awardDirectoryPath);

            if (!directory.Exists)
            {
                directory.Create();
            }
            var awardFiles = new DirectoryInfo(awardDirectoryPath).GetFiles();

            var userAwards = model.ListOfAwards;

            if (model == null)
            {
                return null;
            }
            
            if (userAwards != null)
            {
                foreach (var userAward in model.ListOfAwards.ToList())
                {
                    if (awardFiles.FirstOrDefault(elem => elem.Name.Contains(userAward.ToString())) == default(FileInfo))
                    {
                        model.ListOfAwards.Remove(userAward);
                    }
                }
            }
            
            return new User
            {              
                Name = model.Name,
                DateOfBirth = model.DateOfBirth,
                ListOfAwards = model.ListOfAwards,
                Id = model.Id
            };
        }
    }
}
