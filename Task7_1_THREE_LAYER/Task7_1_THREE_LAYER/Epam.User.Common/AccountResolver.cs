using Epam.Nodes.BLL;
using Epam.Nodes.BLL.Abstract;
//using Epam.Nodes.DAL;
//using Epam.Nodes.DAL.Abstract;
using DatabaseDAO.Abstract;
using DatabaseDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.User.Common
{
   public class AccountResolver
    {
        private static readonly IAccountLogic _accountLogic;
        private static readonly AccountDAO _accountDAO;
        public static IAccountLogic accountLogic => _accountLogic;
        public static IAccountRepository accountRepository => _accountDAO;
        static AccountResolver()
        {
           // _accountRepository = new AccountRepository();
            _accountDAO = new AccountDAO();
            _accountLogic = new AccountLogic(_accountDAO);
           // _accountLogic = new AccountLogic(_accountRepository);
        }
    }
}
