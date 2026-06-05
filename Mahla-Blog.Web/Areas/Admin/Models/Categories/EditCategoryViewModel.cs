using System.ComponentModel.DataAnnotations;

namespace Mahla_Blog.Web.Areas.Admin.Models.Categories
{
    public class EditCategoryViewModel
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
    }
}
