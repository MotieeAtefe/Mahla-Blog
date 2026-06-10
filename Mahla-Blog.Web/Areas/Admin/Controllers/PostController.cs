using Mahla_Blog.CoreLayer.DTOs.Posts;
using Mahla_Blog.CoreLayer.Services.Posts;
using Microsoft.AspNetCore.Mvc;

namespace Mahla_Blog.Web.Areas.Admin.Controllers
{
    public class PostController : Controller
    {
        readonly IPostServise _postServise;

        public PostController(IPostServise postServise)
        {
            _postServise = postServise;
        }
        [Area("Admin")]
        public IActionResult Index(int pageId = 1, string title = "", string categorySlug = "")
        {
            var param = new PostFilterParams()
            {
                PageId = pageId,
                Title = title,
                CategorySlug = categorySlug,
                Take=20
            };
            var model = _postServise.GetPostByFilter(param);
            return View(model);
        }
    }
}
