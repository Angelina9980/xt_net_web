using Entities.Abstract;


namespace Entities
{
    public class FeedBackMessage: BaseEntity
    {
        public string Name { get; set; }
        public string UserMail { get; set; }
        public string Subject { get; set; }
        public string MailText { get; set; }
    }
}
