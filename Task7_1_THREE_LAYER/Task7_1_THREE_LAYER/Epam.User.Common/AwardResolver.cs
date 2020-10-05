using Epam.Nodes.BLL;
using Epam.Nodes.BLL.Abstract;
using Epam.Nodes.DAL;
using Epam.Nodes.DAL.Abstract;

namespace Epam.Common
{
    public class AwardResolver
    {
        private static readonly IAwardLogic _awardLogic;
        private static readonly IAwardRepository _awardRepository;
        public static IAwardLogic AwardLogic => _awardLogic;
        public static IAwardRepository AwardRepository => _awardRepository;
        static AwardResolver()
        {
            _awardRepository = new AwardRepository();
            _awardLogic = new AwardLogic(_awardRepository);
        }
    }
}
