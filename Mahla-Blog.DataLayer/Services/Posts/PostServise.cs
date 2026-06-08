using Mahla_Blog.CoreLayer.DTOs.Posts;
using Mahla_Blog.CoreLayer.Mappers;
using Mahla_Blog.CoreLayer.Utilities;
using Mahla_Blog_DataLayer.Context;
using System.Linq;

namespace Mahla_Blog.CoreLayer.Services.Posts
{
    public class PostServise : IPostServise
    {
        private readonly BlogContext _context;

        public PostServise(BlogContext context)
        {
            _context = context;
        }
        public OperationResult CreatePost(CreatePostDto postDto)
        {
            var post = PostMapper.MapCreateDtoToPost(postDto);
            _context.Add(post);
            _context.SaveChanges();
            return OperationResult.Success();
        }

        public OperationResult EditPost(EditPostDto postDto)
        {
            var post = _context.Posts.FirstOrDefault(p => p.Id == postDto.PostId);
            if (post == null)
                return OperationResult.NotFound();
            post = PostMapper.EditPost(postDto, post);
            _context.SaveChanges();
            return OperationResult.Success();
        }

        public PostDto GetPostById(int id)
        {
            var post = _context.Posts.FirstOrDefault(p => p.Id == id);
            return PostMapper.MapToDto(post);

        }

        public bool IsSlugExists(string slug)
        {
            return _context.Posts.Any(p => p.Slug == slug.ToSlug());
        }
    }
}
