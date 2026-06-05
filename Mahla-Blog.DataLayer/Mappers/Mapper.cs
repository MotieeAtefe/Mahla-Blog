using Mahla_Blog.CoreLayer.DTOs.Categories;
using Mahla_Blog_DataLayer.Entities;

namespace Mahla_Blog.CoreLayer.Mappers
{
    public class Mapper
    {
        public static CategoriesDto MapperCategury(Category categoriesDto)
        {
            return new CategoriesDto()
            {
                id = categoriesDto.Id,
                Title = categoriesDto.Title,
                Slug = categoriesDto.Slug,
                ParentId = categoriesDto.ParentId,
                MetaDescription = categoriesDto.MetaDescription,
                MetaTag = categoriesDto.MetaTag
            };
        }

     
    }
}
