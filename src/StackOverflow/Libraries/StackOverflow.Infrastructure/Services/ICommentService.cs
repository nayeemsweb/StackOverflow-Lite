using StackOverflow.Infrastructure.BusinessObjects;

namespace StackOverflow.Infrastructure.Services
{
	public interface ICommentService
	{
        void CreateComment(Comment comment);
        void UpdateComment(Comment comment);
        void DeleteComment(int id);
        public IList<Comment> GetAllCommentsByPostId(int id);
        Comment GetCommentById(int id);
    }
}
