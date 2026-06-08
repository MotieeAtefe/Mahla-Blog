using Microsoft.AspNetCore.Mvc;

namespace Mahla_Blog.Web.Areas.Admin.Controllers
{
    public class PostController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
