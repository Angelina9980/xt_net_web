using BLL.Abstract;
using System.Collections.Generic;

namespace Controllers
{
    public class SubscriptionController
    {
        private readonly ISubcriptionLogic _subcriptionLogic;

        public SubscriptionController(ISubcriptionLogic subcriptionLogic)
        {
            _subcriptionLogic = subcriptionLogic;
        }

        public void CancelSubcription(string userEmail)
        {
            _subcriptionLogic.CancelSubcription(userEmail);
        }

        public void GetSubcription(string userEmail)
        {
            _subcriptionLogic.GetSubcription(userEmail);
        }

        public bool SubcriptionCheck(string userEmail)
        {
            return _subcriptionLogic.SubcriptionCheck(userEmail);
        }
        public List<string> SubscriptionList()
        {
            return _subcriptionLogic.SubscriptionList();
        }
    }
}
