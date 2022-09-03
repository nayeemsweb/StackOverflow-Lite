using StackOverflow.Infrastructure.Data;
using StackOverflow.Infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflow.Infrastructure.UnitOfWorks
{
    public class StackOverflowUnitOfWork : UnitOfWork, IStackOverflowUnitOfWork
    {
        public StackOverflowUnitOfWork(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
