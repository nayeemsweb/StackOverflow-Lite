using StackOverflow.Infrastructure.BusinessObjects;

namespace StackOverflow.Infrastructure.Services
{
    public interface IPostService
    {
        void CreatePost(Post post);
        void UpdatePost(Post post);
        void DeletePost(int id);
        //(int total, int displayTotal, IList<Post> records) GetPosts(int pageIndex, int pageSize, string searchText, string orderBy);
        public (int total, int displayTotal, IList<Post> records) 
            GetAllPostsByUserId(int pageIndex, int pageSize, string searchText, string orderBy, Guid userId);
        Post GetPostById(int id);
        IList<Post> GetAllPosts();
    }
}
