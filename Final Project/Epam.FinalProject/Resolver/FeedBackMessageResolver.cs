using BLL;
using BLL.Abstract;
using DataBaseDAO;
using DataBaseDAO.Abstract;

namespace Resolver
{
    public class FeedBackMessageResolver
    {
        private static readonly IFeedBackMailLogic _feedBackMailLogic;
        private static readonly IFeedBackMailDAO _feedBackMailDAO;

        public static IFeedBackMailLogic FeedBackMailLogic => _feedBackMailLogic;
        public static IFeedBackMailDAO  FeedBackMailDAO=> _feedBackMailDAO;

        static FeedBackMessageResolver()
        {
            _feedBackMailDAO = new FeedBackMailDAO();
            _feedBackMailLogic = new FeedBackMailLogic(_feedBackMailDAO);
        }
    }
}
