namespace Mahla_Blog.CoreLayer.DTOs.Posts
{
    public class PostFilterParams
    {
        public string CategorySlug { get; set; }
        public string Title { get; set; }
        public int Take { get; set; }
        public int PageId { get; set; }
    }
}