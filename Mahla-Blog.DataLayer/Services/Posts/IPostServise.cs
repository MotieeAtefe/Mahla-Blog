using Mahla_Blog.CoreLayer.DTOs.Posts;
using Mahla_Blog.CoreLayer.Utilities;

namespace Mahla_Blog.CoreLayer.Services.Posts
{
    public interface IPostServise
    {
        OperationResult CreatePost(CreatePostDto postDto);
        OperationResult EditPost(EditPostDto postDto);
        PostDto GetPostById(int id);
        bool IsSlugExists(string slug);
    }
}
