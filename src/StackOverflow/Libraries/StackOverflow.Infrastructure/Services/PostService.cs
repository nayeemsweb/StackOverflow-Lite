using AutoMapper;
using StackOverflow.Infrastructure.BusinessObjects;
using StackOverflow.Infrastructure.UnitOfWorks;
using PostEntity = StackOverflow.Infrastructure.Entities.Post;

namespace StackOverflow.Infrastructure.Services
{
    public class PostService : IPostService
    {
        private readonly IStackOverflowUnitOfWork _stackOverflowUnitOfWork;
        private readonly IMapper _mapper;

        public PostService(IStackOverflowUnitOfWork stackOverflowUnitOfWork,
            IMapper mapper)
        {
            _stackOverflowUnitOfWork = stackOverflowUnitOfWork;
            _mapper = mapper;
        }

        public void CreatePost(Post post)
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

        public void UpdatePost(Post post)
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

        public Post GetPostById(int id)
        {
            var postEntity = _stackOverflowUnitOfWork.PostRepository.GetById(id);

            if (postEntity is null)
                throw new InvalidOperationException("Post with this id not found.");

            var post = _mapper.Map<Post>(postEntity);
            return post;
        }

        public IList<Post> GetAllPosts()
        {
            var postEntities = _stackOverflowUnitOfWork.PostRepository.GetAll();

            var products = new List<Post>();

            foreach (PostEntity entity in postEntities)
            {
                products.Add(_mapper.Map<Post>(entity));
            }

            return products;
        }

        //public Task<(int total, int displayTotal, IList<Post> records)>
        //    GetPosts(int pageIndex, int pageSize, string searchText, string orderBy)
        //{
        //    var result = _stackOverflowUnitOfWork.PostRepository.GetDynamic(x => x.Title.Contains(searchText),
        //        orderBy, string.Empty, pageIndex, pageSize, true);

        //    var posts = new List<Post>();

        //    foreach (PostEntity entity in result.data)
        //    {
        //        posts.Add(_mapper.Map<Post>(entity));
        //    }

        //    return (result.total, result.totalDisplay, posts);
        //}
    }
}
