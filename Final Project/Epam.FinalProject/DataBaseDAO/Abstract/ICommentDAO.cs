
using Entities;
using System.Collections.Generic;

namespace DataBaseDAO.Abstract
{
    public interface ICommentDAO
    {
        void AddComment(string UserName, string Text, int animalId);
        void DeleteComment(int commentId);
        List<CommentEntity> GetAllCommentsById(int animalId);
    }
}
