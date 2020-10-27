using BLL;
using BLL.Abstract;
using DataBaseDAO;
using DataBaseDAO.Abstract;

namespace Resolver
{
    public class SubscriptionResolver
    {
        private static readonly ISubcriptionLogic _subcriptionLogic;
        private static readonly ISubsriptionDAO _subsriptionDAO;

        public static ISubcriptionLogic SubcriptionLogic => _subcriptionLogic;
        public static ISubsriptionDAO SubsriptionDAO => _subsriptionDAO;

        static SubscriptionResolver()
        {
            _subsriptionDAO = new SubcriptionDAO();
            _subcriptionLogic = new SubscriptionLogic(_subsriptionDAO);
        }
    }
}
