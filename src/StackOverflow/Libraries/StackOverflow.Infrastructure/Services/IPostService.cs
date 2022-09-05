using StackOverflow.Infrastructure.BusinessObjects;

namespace StackOverflow.Infrastructure.Services
{
    public interface IPostService
    {
        Task CreatePost(Post post);
        Task UpdatePost(Post Post);
        Task DeletePostAsync(Guid id);
        Task<(int total, int displayTotal, IList<Post> records)> GetPostsAsync(int pageIndex, int pageSize, string searchText, string orderBy);
        Task<Post> GetPostByIdAsync(Guid id);
    }
}
