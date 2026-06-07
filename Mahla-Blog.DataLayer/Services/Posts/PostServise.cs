using System.Linq;
using Mahla_Blog_DataLayer.Context;
using Mahla_Blog.CoreLayer.DTOs.Posts;
using Mahla_Blog.CoreLayer.Utilities;
using Mahla_Blog_DataLayer.Entities;

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
            var post = new Post()
            {
                UserId = postDto.UserId,
                CategoryId = postDto.CategoryId,
                Title = postDto.Title,
                Slug = postDto.Slug,
                Description = postDto.Description
            };
            _context.Add(post);
            _context.SaveChanges();
            return OperationResult.Success();


        }

        public OperationResult EditPost(EditPostDto postDto)
        {
            var post = _context.Posts.FirstOrDefault(p => p.Id == postDto.PostId);
            if (post == null)
                return OperationResult.NotFound();
            post.Id = postDto.PostId;
            post.UserId = postDto.UserId;
            post.CategoryId = postDto.CategoryId;
            post.Title = postDto.Title;
            post.Slug = postDto.Slug;
            post.Description = postDto.Description;
            post.ImageName = postDto.ImageName;

            _context.SaveChanges();
            return OperationResult.Success();

        }
    }
}
