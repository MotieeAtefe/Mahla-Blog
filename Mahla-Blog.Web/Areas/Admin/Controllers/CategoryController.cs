using Mahla_Blog.CoreLayer.DTOs.Categories;
using Mahla_Blog.CoreLayer.Services.Categories;
using Mahla_Blog.CoreLayer.Utilities;
using Mahla_Blog.Web.Areas.Admin.Models.Categories;
using Microsoft.AspNetCore.Mvc;

namespace Mahla_Blog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            return View(_categoryService.GetAllCategories());
        }
        [Route("/admin/category/add/{parentId?}")]
        public IActionResult Add(int? parentId)
        {
            return View();
        }
        [HttpPost("/admin/category/add/{parentId?}")]
        public IActionResult Add(int? parentId, CreateCategoryViewModel viewModel)
        {
            viewModel.ParentId = parentId;
            var result = _categoryService.CreateCategory(viewModel.MapperCategury());

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(nameof(viewModel.Slug), result.Message);
                return View();
            }

            return RedirectToAction("Index");

        }
        public IActionResult Edit(int id)
        {
            var result = _categoryService.GetCategoryBy(id);
            if (result == null)
            {
                return RedirectToAction("Index");
            }

            var model = new EditCategoryViewModel()
            {
                Title = result.Title,
                Slug = result.Slug,
                MetaTag = result.MetaTag,
                MetaDescription = result.MetaDescription
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(int id, EditCategoryViewModel EditModel)
        {

            var result = _categoryService.EditCategory(new EditCategoryDto()
            {
                Title = EditModel.Title,
                Slug = EditModel.Slug,
                MetaTag = EditModel.MetaTag,
                MetaDescription = EditModel.MetaDescription,
                Id = id

            });

            if (result.Status != OperationResultStatus.Success)
            {
                ModelState.AddModelError(nameof(EditModel.Slug), result.Message);
                return View();
            }

            return RedirectToAction("index");
        }
    }
}
