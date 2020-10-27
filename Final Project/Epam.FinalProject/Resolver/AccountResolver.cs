using BLL;
using BLL.Abstract;
using DataBaseDAO;
using DataBaseDAO.Abstract;

namespace Resolver
{
    public class AccountResolver
    {
        private static readonly IAccountLogic _accountLogic;
        private static readonly IAccountDAO _accountDAO;
        public static IAccountLogic AccountLogic => _accountLogic;
        public static IAccountDAO AccountDAO => _accountDAO;
        static AccountResolver()
        {
            _accountDAO = new AccountDAO();
            _accountLogic = new AccountLogic(_accountDAO);
        }
    }
}
