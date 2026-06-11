using Mahla_Blog.CoreLayer.DTOs.Posts;
using Mahla_Blog.CoreLayer.Services.Posts;
using Microsoft.AspNetCore.Mvc;

namespace Mahla_Blog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PostController : Controller
    {
        readonly IPostServise _postServise;

        public PostController(IPostServise postServise)
        {
            _postServise = postServise;
        }
        public IActionResult Index(int pageId = 1, string title = "", string categorySlug = "")
        {
            var param = new PostFilterParams()
            {
                PageId = pageId,
                Title = title,
                CategorySlug = categorySlug,
                Take = 20
            };
            var model = _postServise.GetPostByFilter(param);
            return View(model);
        }

        public IActionResult Add()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Add(string t)
        //{
        //    return View();
        //}
    }
}
