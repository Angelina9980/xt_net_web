using BLL;
using BLL.Abstract;
using DataBaseDAO;
using DataBaseDAO.Abstract;

namespace Resolver
{
    public class CommentResolver
    {
        private static readonly ICommentLogic _commentLogic;
        private static readonly ICommentDAO _commentDAO;

        public static ICommentLogic CommentLogic => _commentLogic;
        public static ICommentDAO CommentDAO => _commentDAO;
        static CommentResolver()
        {
            _commentDAO = new CommentDAO();
            _commentLogic = new CommentLogic(_commentDAO);
        }
    }
}
