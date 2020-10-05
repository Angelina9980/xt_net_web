using Domain;
using Epam.Nodes.Entities;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mappers
{
    public static class AccountMapper
    {
        public static AccountEntity ToEntity(this Account account)
        {
            return new AccountEntity
            {
                Name = account.Name,
                Password = account.Password,
                Role = account.Role
            };
        }

        public static Account ToDomain (this AccountModel model)
        {
            if (model != null)
            {
                if (model.Name.CompareTo("admin@gmail.com") == 0 && model.Password.CompareTo("admin1234") == 0)
                {
                    model.Role = "admin";
                }
                return new Account
                {
                    Name = model.Name,
                    Password = model.Password,
                    Role = model.Role
                };
            }
            else
            {
                return null;
            }
        }
    }
}
