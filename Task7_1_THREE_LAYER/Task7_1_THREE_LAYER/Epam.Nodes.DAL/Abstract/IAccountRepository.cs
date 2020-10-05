using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Nodes.Entities;

namespace Epam.Nodes.DAL.Abstract
{
   public interface IAccountRepository
    {
        void Registration(AccountEntity account);
        string[] GetRole(string username);

    }
}
