using Autofac;
using Microsoft.AspNetCore.Mvc;
using StackOverflow.Web.Models;
using System.Diagnostics;

namespace StackOverflow.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILifetimeScope _scope;

        public HomeController(ILogger<HomeController> logger,
            ILifetimeScope scope)
        {
            _logger = logger;
            _scope = scope;
        }

        public async Task<IActionResult> Index()
        {
            var model = _scope.Resolve<AllPostModel>();
            model.ResolveDependency(_scope);
            await model.GetPosts();
            
            return View(model);
        }

        public async Task<IActionResult> PostDetails(int id)
        {
            var model = _scope.Resolve<PostDetailsModel>();
            model.ResolveDependency(_scope);
            await model.GetPostDetails(id);
            return View(model);
        }

        public async Task<IActionResult> UpdateComment(int id)
        {
            var model = _scope.Resolve<UpdateCommentModel>();
            model.ResolveDependency(_scope);
            model.LoadData(id);
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateComment(UpdateCommentModel model)
        {
            model.ResolveDependency(_scope);
            if (ModelState.IsValid)
            {
                try
                {
                    await model.UpdateComment();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                }
            }
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}