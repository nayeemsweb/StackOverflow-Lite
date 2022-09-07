using Autofac;
using AutoMapper;
using StackOverflow.Infrastructure.BusinessObjects;
using StackOverflow.Infrastructure.Services;
using StackOverflow.Membership.Services;

namespace StackOverflow.Web.Models
{
	public class AllPostModel : BaseModel
	{
        private IPostService _postService;
        public AllPostModel(IPostService postService,
            UserManager userManager,
            HttpContextAccessor httpContextAccessor,
            IMapper mapper)
            : base(userManager, httpContextAccessor, mapper)
        {
            _postService = postService;
        }

        public AllPostModel()
        {

        }

        public override void ResolveDependency(ILifetimeScope scope)
        {
            _scope = scope;
            _postService = _scope.Resolve<IPostService>();

            base.ResolveDependency(scope);
        }

        public IList<Post> Posts { get; set; }
        public async Task GetPosts()
        {
            Posts = (_postService.GetPosts(1, 100, null, "CreatedAt DESC")).records;
        }
    }
}
