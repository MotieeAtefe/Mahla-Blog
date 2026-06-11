using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Mahla_Blog.Web.Areas.Admin.Models.Posts
{
    public class CreatePostViewModel
    {
        [Display(Name = " انتخاب دسته بندی ")]
        [Required(ErrorMessage = "لطفا {0} وارد کنید")]
        public int CategoryId { get; set; }

        [Display(Name = " انتخاب دسته بندی ")]
        [Required(ErrorMessage = "لطفا {0} وارد کنید")]
        public int? SubCategoryId { get; set; }

        [Display(Name = " عنوان ")]
        [Required(ErrorMessage = "لطفا {0} وارد کنید")]
        public string Title { get; set; }

        [UIHint("Ckeditor4")]
        [Display(Name = " توضیحات ")]
        [Required(ErrorMessage = "لطفا {0} وارد کنید")]
        public string Description { get; set; }

        [Display(Name = " slug ")]
        [Required(ErrorMessage = "لطفا {0} وارد کنید")]
        public string Slug { get; set; }

        [Display(Name = " عکس ")]
        [Required(ErrorMessage = "لطفا {0} وارد کنید")]
        public IFormFile ImageFile { get; set; }
    }
}
