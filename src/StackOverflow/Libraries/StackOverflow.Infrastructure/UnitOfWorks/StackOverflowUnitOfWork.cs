using Microsoft.EntityFrameworkCore;
using StackOverflow.Infrastructure.Data;
using StackOverflow.Infrastructure.DbContexts;
using StackOverflow.Infrastructure.Repositories;

namespace StackOverflow.Infrastructure.UnitOfWorks
{
    public class StackOverflowUnitOfWork : UnitOfWork, IStackOverflowUnitOfWork
    {
       public StackOverflowUnitOfWork(IApplicationDbContext dbContext,
            IPostRepository postRepository,
            ICommentRepository commentRepository) 
            : base((DbContext)dbContext)
        {
            PostRepository = postRepository;
            CommentRepository = commentRepository;
        }

        public IPostRepository PostRepository { get; set; }
        public ICommentRepository CommentRepository { get; set; }
    }
}