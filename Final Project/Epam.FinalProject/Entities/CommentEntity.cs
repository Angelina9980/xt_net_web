using Entities.Abstract;

namespace Entities
{
    public class CommentEntity:BaseEntity
    {
        public string Text { get; set; }
        public string UserMail { get; set; }
        public int ID_animal { get; set; }
    }
}
