using AutoMapper;
using StackOverflow.Infrastructure.UnitOfWorks;
using CommentEntity = StackOverflow.Infrastructure.Entities.Comment;
using CommentBO = StackOverflow.Infrastructure.BusinessObjects.Comment;

namespace StackOverflow.Infrastructure.Services
{
    public class CommentService : ICommentService
    {
        private readonly IStackOverflowUnitOfWork _stackOverflowUnitOfWork;
        private IMapper _mapper;

        public CommentService(IStackOverflowUnitOfWork stackOverflowUnitOfWork,
            IMapper mapper)
        {
            _stackOverflowUnitOfWork = stackOverflowUnitOfWork;
            _mapper = mapper;
        }

        public void CreateComment(CommentBO comment)
        {
            if(comment == null)
            {
                throw new ArgumentNullException("No comment string written.");
            }

            var commentEntity = _mapper.Map<CommentEntity>(comment);
            _stackOverflowUnitOfWork.CommentRepository.Add(commentEntity);
            _stackOverflowUnitOfWork.Save();
        }

        public void UpdateComment(CommentBO comment)
        {
            if (comment == null)
            {
                throw new ArgumentNullException("No comment string written.");
            }

            var commentEntity = _stackOverflowUnitOfWork.CommentRepository.GetById(comment.Id);

            if (commentEntity is null)
                throw new InvalidOperationException("No comment found.");

            _mapper.Map(comment, commentEntity);
            _stackOverflowUnitOfWork.Save();
        }

        public void DeleteComment(int id)
        {
            _stackOverflowUnitOfWork.CommentRepository.Remove(id);
            _stackOverflowUnitOfWork.Save();
        }

        public IList<CommentBO> GetAllCommentsByPostId(int id)
        {
            throw new NotImplementedException();
        }

        public CommentBO GetCommentById(int id)
        {
            var commentEntity = _stackOverflowUnitOfWork.CommentRepository.
                Get(x => x.Id == id, "ApplicationUser,Post").FirstOrDefault();

            if (commentEntity is null)
                throw new InvalidOperationException("Comment with this id not found.");

            var comment = _mapper.Map<CommentBO>(commentEntity);
            return comment;
        }
    }
}