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

        public PostFilterDto GetPostByFilter(PostFilterParams param)
        {
            var result = _context.Posts.OrderByDescending(d => d.CreationDate).AsQueryable();
            if (string.IsNullOrWhiteSpace(param.CategorySlug))
                result = result.Where(p => p.Slug == param.CategorySlug);
            if (string.IsNullOrWhiteSpace(param.Title))
                result = result.Where(p => p.Title.Contains(param.Title));
            var skip = (param.PageId - 1) * param.Take;
            var pageCount = result.Count() / param.Take;

            return new PostFilterDto()
            {
                Posts = result.Skip(skip).Take(param.Take).Select(post => PostMapper.MapToDto(post)).ToList(),
                FilterParams = param,
                PageCount = pageCount
            };
        }
    }
}
