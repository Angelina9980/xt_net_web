using BLL.Abstract;
using System.Collections.Generic;
using Entities;

namespace Controllers
{
    public class FeedBackMessageController
    {
        private readonly IFeedBackMailLogic _feedBackMailLogic;

        public FeedBackMessageController(IFeedBackMailLogic feedBackMailLogic)
        {
            _feedBackMailLogic = feedBackMailLogic;
        }

        public void SendEmail(FeedBackMessage feedBackMessage)
        {
            _feedBackMailLogic.SendEmail(feedBackMessage);
        }

        public List<FeedBackMessage> GetAllMessages()
        {
            return _feedBackMailLogic.GetAllMessages();
        }
    }
}
