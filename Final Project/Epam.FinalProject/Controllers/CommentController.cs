using BLL.Abstract;
using Entities;
using System.Collections.Generic;

namespace Controllers
{
    public class CommentController
    {
        private readonly ICommentLogic _commentLogic;

        public CommentController(ICommentLogic commentLogic)
        {
            _commentLogic = commentLogic;
        }

        public void AddComment(string UserName, string Text, int animalId)
        {
            _commentLogic.AddComment(UserName, Text, animalId);
        }

        public void DeleteComment(int commentId)
        {
            _commentLogic.DeleteComment(commentId);
        }

        public List<CommentEntity> GetAllCommentsById(int animalId)
        {
            return _commentLogic.GetAllCommentsById(animalId);
        }
    }
}
