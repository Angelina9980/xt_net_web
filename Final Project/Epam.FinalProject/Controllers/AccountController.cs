using BLL.Abstract;
using System.Collections.Generic;
using Entities;

namespace Controllers
{
    public class AccountController
    {

        private readonly IAccountLogic _accountLogic;
        public AccountController(IAccountLogic accountLogic)
        {
            _accountLogic = accountLogic;
        }
        public void DeleteAccountById(int id)
        {
            _accountLogic.DeleteAccountById(id);
        }

        public void EditAccount(AccountEntity account)
        {
            _accountLogic.EditAccount(account);
        }

        public AccountEntity GetAccountByEmail(string email)
        {
            return _accountLogic.GetAccountByEmail(email);
        }

        public List<AccountEntity> GetAllAccounts()
        {
            return _accountLogic.GetAllAccounts();
        }

        public string[] GetRole(string username)
        {
            return _accountLogic.GetRole(username);
        }

        public void Registration(AccountEntity account)
        {
            _accountLogic.Registration(account);
        }
        public void EditBalance(string email, int cost, bool Operation)
        {
            _accountLogic.EditBalance(email, cost, Operation);
        }

        public AccountEntity GetAccountById(int id)
        {
            return _accountLogic.GetAccountById(id);
        }

    }
}
