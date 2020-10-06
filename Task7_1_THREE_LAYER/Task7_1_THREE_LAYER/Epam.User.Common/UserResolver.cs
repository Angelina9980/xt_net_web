using Epam.Nodes.BLL;
using Epam.Nodes.BLL.Abstract;
//using Epam.Nodes.DAL;
//using Epam.Nodes.DAL.Abstract;
using DatabaseDAO;
using DatabaseDAO.Abstract;
using Epam.Nodes.DAL;

namespace Epam.Common
{
    public class UserResolver
    {
        private static readonly IUserLogic _userLogic;
        private static readonly IUserRepository _userRepository;
        public static IUserLogic UserLogic => _userLogic;
        public static IUserRepository UserRepository => _userRepository;

        static UserResolver()
        {
            // _userRepository = new UserRepository();
            //_userLogic = new UserLogic(_userRepository);
            _userRepository = new UserDAO();
            _userLogic = new UserLogic(_userRepository);

        }
    }
}
