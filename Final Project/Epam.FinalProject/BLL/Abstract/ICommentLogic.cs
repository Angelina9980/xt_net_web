using System.Collections.Generic;
using Entities;

namespace BLL.Abstract
{
    public interface ICommentLogic
    {
        void AddComment(string UserName, string Text, int animalId);
        void DeleteComment(int commentId);
        List<CommentEntity> GetAllCommentsById(int animalId);
    }
}
