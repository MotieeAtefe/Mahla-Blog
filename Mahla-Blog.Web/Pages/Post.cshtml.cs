using Mahla_Blog.CoreLayer.DTOs.Posts;
using Mahla_Blog.CoreLayer.Services.Posts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Mahla_Blog.Web.Pages
{
    public class PostModel : PageModel
    {
        private readonly IPostServise _post;

        public PostModel(IPostServise post)
        {
            _post = post;
        }

        public PostDto Post { get; set; }
        public IActionResult OnGet(string slug)
        {
            Post = _post.GetPostBySlug(slug);
            if (Post == null)
                return NotFound();
            return Page();
        }
    }
}
