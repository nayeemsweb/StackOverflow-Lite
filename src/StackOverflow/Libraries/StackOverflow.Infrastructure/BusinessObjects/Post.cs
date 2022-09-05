using StackOverflow.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverflow.Infrastructure.BusinessObjects
{
    public class Post
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public List<Comment>? Comments { get; set; }
        public List<Vote>? Votes { get; set; }
        public List<Tag>? Tags { get; set; }
    }
}
