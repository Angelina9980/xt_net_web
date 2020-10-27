
using System.Collections.Generic;

namespace DataBaseDAO.Abstract
{
    public interface ISubsriptionDAO
    {
        bool SubcriptionCheck(string userEmail);
        void GetSubcription(string userEmail);
        void CancelSubcription(string userEmail);
        List<string> SubscriptionList();
    }
}
