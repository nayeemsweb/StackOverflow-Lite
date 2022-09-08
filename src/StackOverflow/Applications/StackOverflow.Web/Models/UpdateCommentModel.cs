using Autofac;
using AutoMapper;
using StackOverflow.Infrastructure.BusinessObjects;
using StackOverflow.Infrastructure.Services;
using StackOverflow.Membership.Services;
using System.ComponentModel.DataAnnotations;

namespace StackOverflow.Web.Models
{
	public class UpdateCommentModel : BaseModel
	{
		private ICommentService _commentService;

		public UpdateCommentModel(ICommentService commentService,
			UserManager userManager,
            HttpContextAccessor httpContextAccessor,
            IMapper mapper)
			: base(userManager, httpContextAccessor, mapper)
		{
			_commentService = commentService;
		}

		public UpdateCommentModel()
		{

		}

        public override void ResolveDependency(ILifetimeScope scope)
        {
            _scope = scope;
            _commentService = _scope.Resolve<ICommentService>();

            base.ResolveDependency(scope);
        }

        public async Task UpdatePost()
        {

            await GetUserInfoAsync();
            var comment = new Comment
            {
                
                UserId = UserInfo!.Id
            };
            _commentService.UpdateComment(comment);
        }

        public int Id { get; set; }

        [Required]
        [StringLength(1500, ErrorMessage = "Answer can't be more than 1500 characters.")]
        [DataType(DataType.MultilineText)]
        public string? Description { get; set; }

        [DataType(DataType.DateTime)]
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;

        public int PostId { get; set; }
    }
}
