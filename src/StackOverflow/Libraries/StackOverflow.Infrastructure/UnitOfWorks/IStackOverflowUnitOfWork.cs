using StackOverflow.Infrastructure.Data;
using StackOverflow.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflow.Infrastructure.UnitOfWorks
{
    public interface IStackOverflowUnitOfWork : IUnitOfWork
    {
        public IPostRepository PostRepository { get; set; }
    }
}