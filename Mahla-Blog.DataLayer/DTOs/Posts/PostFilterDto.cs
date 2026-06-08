using System.Collections.Generic;
using Mahla_Blog_DataLayer.Entities;

namespace Mahla_Blog.CoreLayer.DTOs.Posts
{
    public class PostFilterDto
    {
        public int PageCount { get; set; }
        public PostFilterParams FilterParams { get; set; }
        public List<PostDto> Posts { get; set; }

    }
}
