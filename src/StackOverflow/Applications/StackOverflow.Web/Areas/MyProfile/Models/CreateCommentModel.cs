using Autofac;
using AutoMapper;
using StackOverflow.Infrastructure.BusinessObjects;
using StackOverflow.Infrastructure.Services;
using StackOverflow.Membership.Services;
using StackOverflow.Web.Models;
using System.ComponentModel.DataAnnotations;

namespace StackOverflow.Web.Areas.MyProfile.Models
{
	public class CreateCommentModel : BaseModel
	{
        private ICommentService _commentService;
        public CreateCommentModel(ICommentService commentService,
            UserManager userManager,
            HttpContextAccessor httpContextAccessor,
            IMapper mapper)
            : base(userManager, httpContextAccessor, mapper)
        {
            _commentService = commentService;
        }

        public CreateCommentModel()
        {

        }

        public override void ResolveDependency(ILifetimeScope scope)
        {
            _scope = scope;
            _commentService = _scope.Resolve<ICommentService>();

            base.ResolveDependency(scope);
        }

        public async Task CreateComment()
        {
            await GetUserInfoAsync();
            var comment = new Comment
            {
                Description = Description,
                UserId = UserInfo!.Id
            };
            _commentService.CreateComment(comment);
        }

        public int Id { get; set; }

        [StringLength(2000, ErrorMessage = "Description can't be more than 2000 characters.")]
        [DataType(DataType.MultilineText)]
        public string? Description { get; set; }

        [DataType(DataType.DateTime)]
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
    }
}