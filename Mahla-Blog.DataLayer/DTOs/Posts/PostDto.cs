using System;
using Mahla_Blog.CoreLayer.DTOs.Categories;

namespace Mahla_Blog.CoreLayer.DTOs.Posts
{
    public class PostDto
    {
        public int PostId { get; set; }
        public string UserFullName { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public int Visit { get; set; }
        public string ImageName { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public CategoriesDto Categories { get; set; }
        public CategoriesDto SubCategories { get; set; }
        public int? SubCategoryId { get; set; }
    }
}
