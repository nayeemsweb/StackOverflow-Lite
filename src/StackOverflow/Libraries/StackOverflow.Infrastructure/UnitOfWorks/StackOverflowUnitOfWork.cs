using StackOverflow.Infrastructure.Data;
using StackOverflow.Infrastructure.DbContexts;
using StackOverflow.Infrastructure.Repositories;

namespace StackOverflow.Infrastructure.UnitOfWorks
{
    public class StackOverflowUnitOfWork : UnitOfWork, IStackOverflowUnitOfWork
    {
        private readonly IPostRepository _postRepository;

        public StackOverflowUnitOfWork(ApplicationDbContext dbContext,
            IPostRepository postRepository) 
            : base(dbContext)
        {
            _postRepository = postRepository;
        }

        public IPostRepository PostRepository { get; set; }
    }
}