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
        public IActionResult Index()
        {
            return View();
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
        
        public IActionResult Update()
        {
            return View();
        }
    }
}
