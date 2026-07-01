namespace Mahla_Blog.CoreLayer.DTOs.Commands
{
    public class CreateCommendDto
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; }
    }
}
