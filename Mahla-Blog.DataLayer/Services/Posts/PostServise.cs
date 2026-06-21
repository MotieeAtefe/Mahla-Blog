using Mahla_Blog.CoreLayer.DTOs.Posts;
using Mahla_Blog.CoreLayer.FileManagers;
using Mahla_Blog.CoreLayer.Mappers;
using Mahla_Blog.CoreLayer.Utilities;
using Mahla_Blog_DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Mahla_Blog.CoreLayer.Services.Posts
{
    public class PostServise : IPostServise
    {
        private readonly BlogContext _context;
        private readonly IFileManager _fileManagers;
        public PostServise(BlogContext context, IFileManager fileManager)
        {
            _context = context;
            _fileManagers = fileManager;
        }
        public OperationResult CreatePost(CreatePostDto postDto)
        {
            if (postDto.ImageFile == null)
                return OperationResult.Error();
            var post = PostMapper.MapCreateDtoToPost(postDto);
           
            if (IsSlugExists(post.Slug))
                return OperationResult.Error("Slug تکراری است");

            post.ImageName = _fileManagers.SaveFileAndReturnName(postDto.ImageFile, Directories.PostImage);
            Console.WriteLine($"UserId being inserted: {post.UserId}");
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
            var newSlug = postDto.Slug;
            if (post.Slug != newSlug)
                if (IsSlugExists(newSlug))
                    return OperationResult.Error("Slug تکراری است");
     
            if (postDto.ImageFile != null)
                _fileManagers.SaveFileAndReturnName(postDto.ImageFile, Directories.PostImage);
            _context.SaveChanges();
            return OperationResult.Success();
        }

        public PostDto GetPostById(int id)
        {
            var post = _context.Posts
                        .Include(c => c.SubCategorys)
                        .Include(c => c.Categorys)
                        .FirstOrDefault(p => p.Id == id);
            return PostMapper.MapToDto(post);

        }

        public bool IsSlugExists(string slug)
        {
            return _context.Posts.Any(p => p.Slug == slug.ToSlug());
        }

        public PostFilterDto GetPostByFilter(PostFilterParams param)
        {
            var result = _context.Posts
                .Include(d => d.Categorys)
                .Include(d => d.SubCategorys)
                .OrderByDescending(d => d.CreationDate).AsQueryable();
            if (!string.IsNullOrWhiteSpace(param.CategorySlug))
                result = result.Where(p => p.Categorys.Slug == param.CategorySlug);
            if (!string.IsNullOrWhiteSpace(param.Title))
                result = result.Where(p => p.Title.Contains(param.Title));
            var skip = (param.PageId - 1) * param.Take;
            var pageCount = (int)Math.Ceiling((double)result.Count() / param.Take);

            return new PostFilterDto()
            {
                Posts = result.Skip(skip).Take(param.Take).Select(post => PostMapper.MapToDto(post)).ToList(),
                FilterParams = param,
                PageCount = pageCount
            };
        }
    }


}
