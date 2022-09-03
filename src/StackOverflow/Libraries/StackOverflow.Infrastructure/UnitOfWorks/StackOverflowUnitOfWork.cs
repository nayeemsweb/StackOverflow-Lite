using StackOverflow.Infrastructure.Data;
using StackOverflow.Infrastructure.DbContexts;

namespace StackOverflow.Infrastructure.UnitOfWorks
{
    public class StackOverflowUnitOfWork : UnitOfWork, IStackOverflowUnitOfWork
    {
        public StackOverflowUnitOfWork(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}