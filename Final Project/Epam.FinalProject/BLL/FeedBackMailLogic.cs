using BLL.Abstract;
using DataBaseDAO.Abstract;
using Entities;
using System.Collections.Generic;

namespace BLL
{
    public class FeedBackMailLogic : IFeedBackMailLogic
    {
        private readonly IFeedBackMailDAO _feedBackMailDAO;

        public FeedBackMailLogic(IFeedBackMailDAO feedBackMailDAO)
        {
            _feedBackMailDAO = feedBackMailDAO;
        }
        public void SendEmail(FeedBackMessage feedBackMessage)
        {
            _feedBackMailDAO.SendEmail(feedBackMessage);
        }

        public List<FeedBackMessage> GetAllMessages()
        {
            return _feedBackMailDAO.GetAllMessages();
        }
    }
}
