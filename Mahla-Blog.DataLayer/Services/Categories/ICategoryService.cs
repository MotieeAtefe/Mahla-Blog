using Mahla_Blog.CoreLayer.DTOs.Categories;
using Mahla_Blog.CoreLayer.Utilities;
using System.Collections.Generic;

namespace Mahla_Blog.CoreLayer.Services.Categories
{
    public interface ICategoryService
    {
        OperationResult CreateCategory(CreateCategoryDto command);
        OperationResult EditCategory(EditCategoryDto command);
        List<CategoriesDto> GetAllCategories();
        List<CategoriesDto> GetChildCategories(int parentid);

        CategoriesDto GetCategoryBy(int id);
        CategoriesDto GetCategoryBy(string slug);
        bool IsExists(string slug);

    }
}
