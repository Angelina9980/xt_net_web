using Entities;
using System.Collections.Generic;

namespace DataBaseDAO.Abstract
{
    public interface IFeedBackMailDAO
    {
        void SendEmail(FeedBackMessage feedBackMessage);
        List<FeedBackMessage> GetAllMessages();
    }
}
