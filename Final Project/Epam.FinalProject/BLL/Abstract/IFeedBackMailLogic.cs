using Entities;
using System.Collections.Generic;

namespace BLL.Abstract
{
    public interface IFeedBackMailLogic
    {
        void SendEmail(FeedBackMessage feedBackMessage);
        List<FeedBackMessage> GetAllMessages();
    }
}
