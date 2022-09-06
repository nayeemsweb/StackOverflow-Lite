using Microsoft.AspNetCore.Mvc;

namespace StackOverflow.Web.Areas.MyProfile.Controllers
{
    [Area("MyProfile")]
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Create()
        {
            return View();
        }
        
        public IActionResult Update()
        {
            return View();
        }
    }
}
