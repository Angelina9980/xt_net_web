using BLL.Abstract;
using DataBaseDAO.Abstract;
using Entities;
using System.Collections.Generic;

namespace BLL
{
    public class AccountLogic : IAccountLogic
    {
        private readonly IAccountDAO _accountDAO;
        public AccountLogic(IAccountDAO accountDAO)
        {
            _accountDAO = accountDAO;
        }

        public void DeleteAccountById(int id)
        {
            _accountDAO.DeleteAccountById(id);
        }

        public void EditAccount(AccountEntity account)
        {
            _accountDAO.EditAccount(account);
        }

        public void EditBalance(string email, int cost, bool Operation)
        {
            _accountDAO.EditBalance(email, cost, Operation);
        }

        public AccountEntity GetAccountByEmail(string email)
        {
            return _accountDAO.GetAccountByEmail(email);
        }

        public AccountEntity GetAccountById(int id)
        {
            return _accountDAO.GetAccountById(id);
        }

        public List<AccountEntity> GetAllAccounts()
        {
            return _accountDAO.GetAllAccounts();
        }

        public string[] GetRole(string username)
        {
            return _accountDAO.GetRole(username);
        }

        public void Registration(AccountEntity account)
        {
            _accountDAO.Registration(account);
        }
    }
}
