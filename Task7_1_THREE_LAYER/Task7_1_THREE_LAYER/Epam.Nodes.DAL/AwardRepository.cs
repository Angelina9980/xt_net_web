using Epam.Nodes.DAL.Abstract;
using Epam.Nodes.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Epam.Nodes.DAL
{
    public class AwardRepository : IAwardRepository
    {
        private readonly string directoryPath = @"C:\AdwardStorage";
        private readonly string fileType = ".json";
        private int awardId = 0;
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
            awardId++;
            award.Id = awardId;
            string userFileName = directoryPath + "\\" + awardId + fileType;
            using (StreamWriter writer = new StreamWriter(userFileName))
            {
                writer.Write(JsonConvert.SerializeObject(award));
            }
        }

        public void DeleteAwardById(int id)
        {
            string userFileName = directoryPath + "\\" + id +  fileType;
            if (File.Exists(userFileName))
            {
                File.Delete(userFileName);
            }
            awardId--;
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
    }
}
