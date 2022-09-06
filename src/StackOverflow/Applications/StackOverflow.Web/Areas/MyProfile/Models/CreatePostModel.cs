using Autofac;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using StackOverflow.Infrastructure.BusinessObjects;
using StackOverflow.Infrastructure.Services;
using StackOverflow.Membership.Services;
using StackOverflow.Web.Models;

namespace StackOverflow.Web.Areas.MyProfile.Models
{
	public class CreatePostModel : BaseModel
	{
        private IPostService _postService;
        public CreatePostModel(IPostService postService,
            UserManager userManager,
            HttpContextAccessor httpContextAccessor,
            IMapper mapper)
            : base(userManager, httpContextAccessor, mapper)
        {
            _postService = postService;
        }

        public CreatePostModel()
        {
        }

        public override void ResolveDependency(ILifetimeScope scope)
        {
            _scope = scope;
            _postService = _scope.Resolve<IPostService>();

            base.ResolveDependency(scope);
        }

        public async Task CreatePost()
        {
            await GetUserInfoAsync();
            var post = new Post
            {
                Title = Title,
                Description = Description,
                UserId = UserInfo!.Id
            };
            _postService.CreatePost(post);
        }

        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        //public string? Tag { get; set; }
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
        public Guid? UserId { get; set; }
    }
}