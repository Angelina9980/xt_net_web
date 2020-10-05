using Epam.Nodes.BLL.Abstract;
using Mappers;
using Models;

namespace Controllers
{
    public class AccountController
    {
        private readonly IAccountLogic _accountLogic;

        public AccountController(IAccountLogic accountLogic)
        {
            _accountLogic = accountLogic;
        }

       public void Registration(AccountModel account)
        {
            _accountLogic.Registration(account.ToDomain());
        }
        public string[] GetRole(string username)
        {
            return _accountLogic.GetRole(username);
        }

    }
}
