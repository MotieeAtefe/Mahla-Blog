using Microsoft.VisualBasic;
using System;

namespace Mahla_Blog.CoreLayer.DTOs.Posts
{
    public class PostDto
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public string ImageName { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
