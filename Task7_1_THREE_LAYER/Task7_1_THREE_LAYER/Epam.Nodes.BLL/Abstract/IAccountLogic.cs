using Domain;

namespace Epam.Nodes.BLL.Abstract
{
    public interface IAccountLogic
    {
        string[] GetRole(string username);
        void Registration(Account account);
    }
}
