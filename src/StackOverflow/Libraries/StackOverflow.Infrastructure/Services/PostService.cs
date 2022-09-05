using AutoMapper;
using StackOverflow.Infrastructure.BusinessObjects;
using StackOverflow.Infrastructure.UnitOfWorks;

namespace StackOverflow.Infrastructure.Services
{
    public class PostService : IPostService
    {
        private readonly IStackOverflowUnitOfWork _stackOverflowUnitOfWork;
        private readonly IMapper _mapper;

        public PostService(IStackOverflowUnitOfWork stackOverflowUnitOfWork,
            IMapper mapper)
        {
            _stackOverflowUnitOfWork = stackOverflowUnitOfWork;
            _mapper = mapper;
        }
        
        public Task CreatePost(Post post)
        {
            throw new NotImplementedException();
        }

        public Task DeletePostAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Post> GetPostByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<(int total, int displayTotal, IList<Post> records)> 
            GetPostsAsync(int pageIndex, int pageSize, string searchText, string orderBy)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePost(Post Post)
        {
            throw new NotImplementedException();
        }
    }
}
