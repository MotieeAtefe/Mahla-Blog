using Mahla_Blog.CoreLayer.DTOs.Categories;
using System.ComponentModel.DataAnnotations;

namespace Mahla_Blog.Web.Areas.Admin.Models.Categories
{
    public class CreateCategoryViewModel
    {
        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "وارد کردن{0} الزامی است")]
        public string Title { get; set; }

        [Display(Name = "Slug")]
        [Required(ErrorMessage = "وارد کردن{0} الزامی است")]
        public string Slug { get; set; }

        [Display(Name = " MetaTag با - از هم جدا کنید")]
        public string MetaTag { get; set; }
        public string MetaDescription { get; set; }
        public int? ParentId { get; set; }
        public  CreateCategoryDto MapperCategury()
        {
            return new CreateCategoryDto()
            {
                Title = Title,
                Slug = Slug,
                ParentId = ParentId,
                MetaDescription = MetaDescription,
                MetaTag = MetaTag
            };
        }

    }
}
