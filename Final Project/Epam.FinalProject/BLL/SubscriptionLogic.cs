using BLL.Abstract;
using DataBaseDAO.Abstract;
using System.Collections.Generic;

namespace BLL
{
    public class SubscriptionLogic : ISubcriptionLogic
    {
        private readonly ISubsriptionDAO _subsriptionDAO;
        public SubscriptionLogic(ISubsriptionDAO subsriptionDAO)
        {
            _subsriptionDAO = subsriptionDAO;
        }

        public void CancelSubcription(string userEmail)
        {
            _subsriptionDAO.CancelSubcription(userEmail);
        }

        public void GetSubcription(string userEmail)
        {
            _subsriptionDAO.GetSubcription(userEmail);
        }
        public bool SubcriptionCheck(string userEmail)
        {
            return _subsriptionDAO.SubcriptionCheck(userEmail);
        }

        public List<string> SubscriptionList()
        {
            return _subsriptionDAO.SubscriptionList();
        }
    }
}
