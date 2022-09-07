﻿using Autofac;
using Microsoft.AspNetCore.Mvc;
using StackOverflow.Web.Areas.MyProfile.Models;

namespace StackOverflow.Web.Areas.MyProfile.Controllers
{
    [Area("MyProfile")]
    public class PostController : Controller
    {
        private readonly ILifetimeScope _scope;
        private readonly ILogger<PostController> _logger;

        public PostController(ILogger<PostController> logger, 
            ILifetimeScope scope)
        {
            _scope = scope;
            _logger = logger;
        }
        
        public async Task<IActionResult> Index()
        {
            var model = _scope.Resolve<ListPostModel>();
            model.ResolveDependency(_scope);
            await model.GetPosts();

            return View(model);
        }
        
        public IActionResult Create()
        {
            var model = _scope.Resolve<CreatePostModel>();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreatePostModel model)
        {
            model.ResolveDependency(_scope);
            if (ModelState.IsValid)
            {
                try
                {
                    await model.CreatePost();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                }
            }

            return View(model);
        }
        
        public IActionResult Update(int id)
        {
            var model = _scope.Resolve<UpdatePostModel>();            
            model.LoadData(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UpdatePostModel model)
        {
            model.ResolveDependency(_scope);
            if (ModelState.IsValid)
            {
                try
                {
                    await model.UpdatePost();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                }
            }
            return View(model);
        }
    }
}
