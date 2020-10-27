using BLL.Abstract;
using DataBaseDAO.Abstract;
using Entities;
using System.Collections.Generic;

namespace BLL
{
    public class CommentLogic : ICommentLogic
    {
        private readonly ICommentDAO _commentDAO;

        public CommentLogic(ICommentDAO commentDAO)
        {
            _commentDAO = commentDAO;
        }

        public void AddComment(string UserName, string Text, int animalId)
        {
            _commentDAO.AddComment(UserName, Text, animalId);
        }

        public void DeleteComment(int commentId)
        {
            _commentDAO.DeleteComment(commentId);
        }

        public List<CommentEntity> GetAllCommentsById(int animalId)
        {
            return _commentDAO.GetAllCommentsById(animalId);
        }
    }
}
