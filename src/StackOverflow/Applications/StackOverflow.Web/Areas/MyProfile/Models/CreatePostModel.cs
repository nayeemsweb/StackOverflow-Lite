﻿using Autofac;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using StackOverflow.Infrastructure.BusinessObjects;
using StackOverflow.Infrastructure.Services;
using StackOverflow.Membership.Services;
using StackOverflow.Web.Models;
using System.ComponentModel.DataAnnotations;

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

        [StringLength(150, ErrorMessage = "Title can't be more than 150 characters.")]
        [DataType(DataType.Text)]
        public string? Title { get; set; }

        [StringLength(2000, ErrorMessage = "Description can't be more than 150 characters.")]
        [DataType(DataType.MultilineText)]
        public string? Description { get; set; }
        //public string? Tag { get; set; }

        [DataType(DataType.DateTime)]
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
        public Guid? UserId { get; set; }
    }
}