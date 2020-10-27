using Entities;
using System.Collections.Generic;


namespace DataBaseDAO.Abstract
{
   public interface IAccountDAO
    {
        void Registration(AccountEntity account);
        string[] GetRole(string username);
        void DeleteAccountById(int id);
        List<AccountEntity> GetAllAccounts();
        AccountEntity GetAccountByEmail(string email);
        AccountEntity GetAccountById(int id);
        void EditAccount(AccountEntity account);
        void EditBalance(string email, int cost, bool Operation);
    }
}
