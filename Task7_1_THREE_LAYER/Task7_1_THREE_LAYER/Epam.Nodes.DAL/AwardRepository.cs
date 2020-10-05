using Epam.Nodes.DAL.Abstract;
using Epam.Nodes.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace Epam.Nodes.DAL
{
    public class AwardRepository : IAwardRepository
    {
        private readonly string 
            directoryPath = @"C:\AwardStorage",
            fileType = ".json";
        private int awardId = 1;
        public void AddAward(AwardEntity award)
        {
            if (award == null)
            {
                throw new ArgumentNullException();
            }

            DirectoryInfo directory = new DirectoryInfo(directoryPath);
            if (!directory.Exists)
            {
                directory.Create();
            }
            
            if (awardId == 0)
            {
                awardId = 1;
            }

            award.Id = awardId;
            awardId++;
            
            string userFileName = directoryPath + "\\" + award.Id + fileType;
            if (!File.Exists(userFileName) || !GetAllAwards().Equals(award))
            {
                using (StreamWriter writer = new StreamWriter(userFileName))
                {
                    writer.Write(JsonConvert.SerializeObject(award));
                }
            }
        }

        public void DeleteAwardById(int id)
        {
            string awardFileName = directoryPath + "\\" + id + fileType;
            DirectoryInfo userDirectory = new DirectoryInfo(@"C:\UsersStorage");

            if (File.Exists(awardFileName))
            {
                foreach (var user in userDirectory.GetFiles())
                {
                    using (StreamReader reader = new StreamReader(user.FullName))
                    {
                        if (JsonConvert.DeserializeObject<UserEntity>(reader.ReadToEnd()).ListOfAwards.Equals(id))
                        {
                            using (StreamWriter writer = new StreamWriter(user.FullName))
                            {
                                JsonConvert.DeserializeObject<UserEntity>(reader.ReadToEnd()).ListOfAwards.Remove(id);
                            }
                        }

                    }
                }
                File.Delete(awardFileName);
            }
        }

        public void EditAward(AwardEntity award)
        {
            var currentAward = GetAwardById(award.Id);

            if (currentAward.Title != award.Title)
            {
                DeleteAwardById(currentAward.Id);
                awardId--;
                AddAward(new AwardEntity {Title = award.Title, Id = award.Id });
            }
        }

        public List<AwardEntity> GetAllAwards()
        {
            List<AwardEntity> awardEntities = new List<AwardEntity>();
            DirectoryInfo directory = new DirectoryInfo(directoryPath);
            if (directory.Exists)
            {
                foreach (var adwardFile in directory.GetFiles())
                {
                    using (StreamReader reader = new StreamReader(adwardFile.FullName))
                    {
                        awardEntities.Add(JsonConvert.DeserializeObject<AwardEntity>(reader.ReadToEnd()));
                    }
                }
            }
            return awardEntities;
        }
        public AwardEntity GetAwardById(int id)
        {
            var award = GetAllAwards().FirstOrDefault(elem => elem.Id == id);
            if (award != default(AwardEntity))
            {
                return award;
            }
            else
            {
                return null;
            }
        }
    }
}
