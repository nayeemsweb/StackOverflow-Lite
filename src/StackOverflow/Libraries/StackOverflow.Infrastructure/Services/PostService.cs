using AutoMapper;
using StackOverflow.Infrastructure.UnitOfWorks;
using PostEntity = StackOverflow.Infrastructure.Entities.Post;
using PostBO = StackOverflow.Infrastructure.BusinessObjects.Post;
using System.Security.Cryptography.X509Certificates;

namespace StackOverflow.Infrastructure.Services
{
    public class PostService : IPostService
    {
        private readonly IStackOverflowUnitOfWork _stackOverflowUnitOfWork;
        private IMapper _mapper;

        public PostService(IStackOverflowUnitOfWork stackOverflowUnitOfWork,
            IMapper mapper)
        {
            _stackOverflowUnitOfWork = stackOverflowUnitOfWork;
            _mapper = mapper;
        }

        public void CreatePost(PostBO post)
        {
            var postCount = _stackOverflowUnitOfWork.PostRepository
                .GetCount(x => x.Title == post.Title);

            if (postCount == 0)
            {
                var entity = _mapper.Map<PostEntity>(post);

                _stackOverflowUnitOfWork.PostRepository.Add(entity);
                _stackOverflowUnitOfWork.Save();
            }
            else
                throw new Exception("Same post already exist!");
        }

        public void UpdatePost(PostBO post)
        {
            var count = _stackOverflowUnitOfWork.PostRepository
                .GetCount(x => x.Title == post.Title && x.Id != post.Id);

            if (count > 0)
                throw new InvalidOperationException("Same post already exist!");

            var postEntity = _stackOverflowUnitOfWork.PostRepository.GetById(post.Id);

            if (postEntity is null)
                throw new InvalidOperationException("Post with this id not found.");

            _mapper.Map(post, postEntity);
            _stackOverflowUnitOfWork.Save();
        }

        public void DeletePost(int id)
        {
            _stackOverflowUnitOfWork.PostRepository.Remove(id);
            _stackOverflowUnitOfWork.Save();
        }

        public PostBO GetPostById(int id)
        {
            var postEntity = _stackOverflowUnitOfWork.PostRepository.
                Get(x => x.Id == id, "ApplicationUser,Comments,Comments.ApplicationUser,Tags,Votes").FirstOrDefault();

            if (postEntity is null)
                throw new InvalidOperationException("Post with this id not found.");

            var post = _mapper.Map<PostBO>(postEntity);
            return post;
        }

        public IList<PostBO> GetAllPosts()
        {
            var posts = new List<PostBO>();
            
            var postEntities = _stackOverflowUnitOfWork.PostRepository.GetAll();            

            foreach (PostEntity entity in postEntities)
            {
                posts.Add(_mapper.Map<PostBO>(entity));
            }

            return posts;
        }

        public (int total, int displayTotal, IList<PostBO> records) 
            GetAllPosts(int pageIndex, int pageSize, string searchText, string orderBy, Guid userId)
        {
            var posts = new List<PostBO>();
            
            var result = _stackOverflowUnitOfWork.PostRepository
                .GetDynamic(x => x.UserId == userId,
                    orderBy, "ApplicationUser,Tags", pageIndex, pageSize, true);

            if (!string.IsNullOrEmpty(searchText))
            {
                result = _stackOverflowUnitOfWork.PostRepository
                    .GetDynamic(x => x.UserId == userId && x.Title.Contains(searchText),
                    orderBy, "ApplicationUser,Tags", pageIndex, pageSize, true);
            }

            foreach (PostEntity entitiy in result.data)
            {
                posts.Add(_mapper.Map<PostBO>(entitiy));
            }
            return (result.total, result.totalDisplay, posts);
        }

        public (int total, int displayTotal, IList<PostBO> records)
            GetPosts(int pageIndex, int pageSize, string searchTerm, string orderBy)
        {
            var result = _stackOverflowUnitOfWork.PostRepository.GetDynamic(null,
                orderBy, "ApplicationUser,Tags,Votes", pageIndex, pageSize, true);

            if (!string.IsNullOrEmpty(searchTerm))
            {
                result = _stackOverflowUnitOfWork.PostRepository.GetDynamic(x => x.Title.Contains(searchTerm),
                    orderBy, "ApplicationUser,Tags,Votes", pageIndex, pageSize, true);
            }

            var posts = new List<PostBO>();

            foreach (PostEntity entity in result.data)
            {
                posts.Add(_mapper.Map<PostBO>(entity));
            }

            return (result.total, result.totalDisplay, posts);
        }
    }
}
