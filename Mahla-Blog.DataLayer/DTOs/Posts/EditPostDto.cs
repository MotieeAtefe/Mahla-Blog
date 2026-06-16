using Microsoft.AspNetCore.Http;

namespace Mahla_Blog.CoreLayer.DTOs.Posts
{
    public class EditPostDto
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public int SubCategories { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
