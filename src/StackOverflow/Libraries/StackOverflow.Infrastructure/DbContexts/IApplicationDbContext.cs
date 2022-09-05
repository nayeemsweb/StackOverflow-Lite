using Microsoft.EntityFrameworkCore;
using StackOverflow.Infrastructure.Entities.Membership;

namespace StackOverflow.Infrastructure.DbContexts
{
    public interface IApplicationDbContext
    {
        DbSet<ApplicationUser>? ApplicationUsers { get; set; }
    }
}