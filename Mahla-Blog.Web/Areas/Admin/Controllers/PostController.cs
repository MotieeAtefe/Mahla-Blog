using Mahla_Blog.CoreLayer.DTOs.Posts;
using Mahla_Blog.CoreLayer.Services.Posts;
using Mahla_Blog.CoreLayer.Utilities;
using Mahla_Blog.Web.Areas.Admin.Models.Posts;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(CreatePostViewModel postViewModel)
        {
            if (!ModelState.IsValid)
                return View(postViewModel);

            var result = _postServise.CreatePost(new CreatePostDto()
            {
                Title = postViewModel.Title,
                CategoryId = postViewModel.CategoryId,
                Description = postViewModel.Description,
                ImageFile = postViewModel.ImageFile,
                Slug = postViewModel.Slug,
                SubCategoryId = postViewModel.SubCategoryId == 0 ? null : postViewModel.SubCategoryId,
                UserId = User.GetUserId()
            });
            if (result.Status != OperationResultStatus.Success)
            {
                ModelState.AddModelError(nameof(CreatePostViewModel.Slug), result.Message);
                return View(postViewModel);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var post = _postServise.GetPostById(id);
            if (post == null)
                return RedirectToAction("Index");
            var model = new EditPostViewModel()
            {
                CategoryId = post.CategoryId,
                Description = post.Description,
                Slug = post.Slug,
                SubCategoryId = post.SubCategoryId == 0 ? null : post.SubCategoryId,
                Title = post.Title

            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,EditPostViewModel editpost)
        {
            if (!ModelState.IsValid)
                return View(editpost);

            var result = _postServise.EditPost(new EditPostDto()
            {
                CategoryId = editpost.CategoryId,
                Description = editpost.Description,
                Slug = editpost.Slug,
                Title = editpost.Title,
                ImageFile = editpost.ImageFile,
                PostId = id,
                SubCategoryId = editpost.SubCategoryId == 0 ? null : editpost.SubCategoryId,
            });

            if (result.Status != OperationResultStatus.Success)
            {
                ModelState.AddModelError(nameof(EditPostViewModel.Slug), result.Message);
                return View(editpost);
            }
            return RedirectToAction("Index");
        }
    }
}
