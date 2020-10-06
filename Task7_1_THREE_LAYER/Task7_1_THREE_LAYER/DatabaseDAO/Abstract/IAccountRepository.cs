using Epam.Nodes.Entities;

namespace DatabaseDAO.Abstract
{
    public interface IAccountRepository
    {
        void Registration(AccountEntity account);
        string[] GetRole(string username);
    }
}
