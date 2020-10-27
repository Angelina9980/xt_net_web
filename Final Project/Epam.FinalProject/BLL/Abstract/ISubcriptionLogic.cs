using System.Collections.Generic;

namespace BLL.Abstract
{
    public interface ISubcriptionLogic
    {
        bool SubcriptionCheck(string userEmail);
        void GetSubcription(string userEmail);
        void CancelSubcription(string userEmail);
        List<string> SubscriptionList();
    }
}
