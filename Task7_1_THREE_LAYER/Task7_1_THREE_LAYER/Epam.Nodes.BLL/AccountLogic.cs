using Domain;
using Epam.Nodes.BLL.Abstract;
using Epam.Nodes.DAL.Abstract;
using Mappers;

namespace Epam.Nodes.BLL
{
    public class AccountLogic : IAccountLogic
    {
        private readonly IAccountRepository _accountRepository;
        public AccountLogic(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public string[] GetRole(string username)
        {
            return _accountRepository.GetRole(username);
        }

        public void Registration(Account account)
        {
            _accountRepository.Registration(account.ToEntity());
        }
    }
}
