using System.Collections.Generic;
using Mahla_Blog.CoreLayer.DTOs.Posts;
using Mahla_Blog.CoreLayer.Services.Comments;
using Mahla_Blog.CoreLayer.Services.Posts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Windows.Input;
using Mahla_Blog.CoreLayer.DTOs.Commands;
using Mahla_Blog.CoreLayer.Utilities;

namespace Mahla_Blog.Web.Pages
{
    public class PostModel : PageModel
    {
        private readonly IPostServise _post;
        private readonly ICommentService _command;

        public PostModel(IPostServise post, ICommentService command)
        {
            _post = post;
            _command = command;
        }

        public PostDto Post { get; set; }
        public List<CommendDto> Commands { get; set; }

        [BindProperty]
        public int PostId { get; set; }
        [BindProperty]
        public string  Text { get; set; }



        public IActionResult OnGet(string slug)
        {
            Post = _post.GetPostBySlug(slug);
            if (Post == null)
                return NotFound();
            Commands = _command.getCommanList(Post.PostId) ?? new List<CommendDto>();
            return Page();
        }

        public IActionResult OnPost(string slug)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Past", new { slug });
            if (!ModelState.IsValid)
            {
                Post = _post.GetPostBySlug(slug);
                return Page();
            }

            _command.createCommend(new CreateCommendDto()
            {
                PostId = PostId,
                Text = Text,
                UserId = User.GetUserId()
            });
            return RedirectToPage("Post", new {slug});

        }


    }
}
