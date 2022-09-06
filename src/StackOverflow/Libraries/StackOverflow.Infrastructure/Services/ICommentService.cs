using StackOverflow.Infrastructure.BusinessObjects;

namespace StackOverflow.Infrastructure.Services
{
	public interface ICommentService
	{
        void CreateComment(Comment post);
        void UpdateComment(Comment post);
        void DeletePost(int id);
        public IList<Comment> GetAllCommentsByPostId(int id);
    }
}
