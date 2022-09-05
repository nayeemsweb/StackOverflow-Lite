namespace StackOverflow.Infrastructure.BusinessObjects
{
    public class Vote
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public Post? PostId { get; set; }
        public int? CommentId { get; set; }
    }
}
