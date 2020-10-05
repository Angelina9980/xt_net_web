using Epam.Nodes.DAL.Abstract;
using Epam.Nodes.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Epam.Nodes.DAL
{
    public class AccountRepository : IAccountRepository
    {
        private readonly string accountPath = @"C:\AccountStorage";
        private readonly string fileType = ".json";

        public string[] GetRole(string username)
        {
            DirectoryInfo directory = new DirectoryInfo(accountPath);

            if (!directory.Exists)
            {
                directory.Create();
            }

            var accountFile = directory.GetFiles().FirstOrDefault(elem => elem.Name.Contains(username));

            if (accountFile.Name.Contains("admin"))
            {
                return new[] { "admin" };
            }
            else if (accountFile.Name.Contains("user"))
            {
                return new[] { "user" };
            }
            else
            {
                return new[] { "no role" };
            }
        }

        public void Registration(AccountEntity account)
        {
            if (account != null)
            {
                DirectoryInfo directory = new DirectoryInfo(accountPath);
                if (!directory.Exists)
                {
                    directory.Create();
                }
                if (account.Role != "admin")
                {
                    account.Role = "user";
                }
                string accountFileName = accountPath + "\\" + account.Name + "." + account.Role + fileType;

                using (StreamWriter writer = new StreamWriter(accountFileName))
                {
                    writer.Write(JsonConvert.SerializeObject(account));
                }
            }
        }


    }
}
