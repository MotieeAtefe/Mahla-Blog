using Mahla_Blog_DataLayer.Entities;
using Mahla_Blog.CoreLayer.DTOs.Posts;

namespace Mahla_Blog.CoreLayer.Mappers
{
    public class PostMapper
    {
        public static Post MapCreateDtoToPost(CreatePostDto postDto)
        {
            return new Post()
            {
                CategoryId = postDto.CategoryId,
                Description = postDto.Description,
                Slug = postDto.Slug,
                Title = postDto.Title,
                IsDeleted = false,
                Visit = 0,
                UserId = postDto.UserId
            };
        }

        public static Post EditPost(EditPostDto postDto, Post post)
        {
            post.CategoryId = postDto.CategoryId;
            post.Description = postDto.Description;
            post.Slug = postDto.Slug;
            post.Title = postDto.Title;
            return post;
        }

        public static PostDto MapToDto(Post post)
        {
            return new PostDto()
            {
                CategoryId = post.CategoryId,
                Description = post.Description,
                Slug = post.Slug,
                Title = post.Title,
                Visit = post.Visit,
                UserId = post.UserId,
                CreationDate = post.CreationDate,
                Categories = CategoryMapper.MapperCategury(post.Categorys),
                PostId = post.Id,
                ImageName = post.ImageName
                    
            };
        }
    }
}
